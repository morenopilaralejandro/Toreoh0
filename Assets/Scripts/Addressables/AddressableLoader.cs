using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

public static class AddressableLoader 
{
    // fields
    private static CacheLru<string, object> cacheLru;
    private static readonly Dictionary<string, RefCountedAsset> assets = new ();

    // initialize
    public static void Initialize(AddressableConfig addressableConfig) 
    {
        cacheLru = new CacheLru<string, object>(addressableConfig.CacheLruSize);
    }

    // logic
    public static async Task<T> LoadAssetAsync<T>(string address, bool isOptional = false) where T : Object
    {
        if (TryGetFromCache(address, out T asset)) return asset;
        if (isOptional && !await ValidateLocationAsync(address)) return null;
        
        AsyncOperationHandle<T> handle;
        try
        {
            handle = Addressables.LoadAssetAsync<T>(address);
            await handle.Task;
        }
        catch (System.Exception ex)
        {
            CustomLog.Error($"[AddressableLoader] Exception loading {address} \n{ex}");
            return null;
        }

        AddNewAssetToCache(address, handle);
        return handle.Result;
    }

    private static async Task<bool> ValidateLocationAsync(string address)
    {
        var locationHandle = Addressables.LoadResourceLocationsAsync(address);
        await locationHandle.Task;
        bool isValid = 
            locationHandle.Status == AsyncOperationStatus.Succeeded &&
            locationHandle.Result != null &&
            locationHandle.Result.Count > 0;
        Addressables.Release(locationHandle);
        return isValid;
    }

    private static bool TryGetFromCache<T>(string address, out T asset)
    {
        asset = default;
        if (assets.TryGetValue(address, out var refAsset)) 
        {
            refAsset.RefCount++;
            cacheLru.Add(address, refAsset.Handle.Result as Object); //readd to lru
            asset = (T)refAsset.Handle.Result;
            return true;
        }
        return false;
    }

    private static void AddNewAssetToCache<T>(string address, AsyncOperationHandle<T> handle)
    {
        assets[address] = new RefCountedAsset { Handle = handle, RefCount = 1 };
        cacheLru.Add(address, handle.Result);
    }

    public static void Release(string address)
    {
        if (assets.TryGetValue(address, out var refAsset)) 
        {
            refAsset.RefCount--;
            if (refAsset.RefCount <= 0) 
            {
                Addressables.Release(refAsset);
                assets.Remove(address);
                cacheLru.Remove(address);
            }
        }
    }

    public static void ReleaseAll() 
    {
        foreach (var kvp in assets.Values)
            Addressables.Release(kvp.Handle);
        assets.Clear();
        cacheLru.Clear();
    }

    public static void PrintRefCounts() 
    {
        foreach (var kvp in assets) CustomLog.Trace($"{kvp.Key} => {kvp.Value.RefCount}");
    }

    public static async Task<T> LoadAssetAsyncRequired<T>(string address) where T : Object => await LoadAssetAsync<T>(address, isOptional : false);
    public static async Task<T> LoadAssetAsyncOptional<T>(string address) where T : Object => await LoadAssetAsync<T>(address, isOptional : true);
}
