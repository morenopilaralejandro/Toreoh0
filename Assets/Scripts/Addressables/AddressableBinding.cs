using UnityEngine;
using System.Threading.Tasks;

public class AddressableBinding<T> where T : Object
{
    private string address;
    private int version;

    private async Task<T> LoadAssetAsyncInternal(string address, bool isOptional)
    {
        int versionAux = ++version;
        Release();
        this.address = address;

        T asset = await AddressableLoader.LoadAssetAsync<T>(address, isOptional);

        if (versionAux != version)
        {
            if (asset != null) AddressableLoader.Release(address);
            return null;
        }

        return asset;
    }

    public async Task<T> LoadAssetAsync(string address) => await LoadAssetAsyncInternal(address, isOptional : false);
    public async Task<T> LoadAssetAsyncOptional(string address) => await LoadAssetAsyncInternal(address, isOptional : true);

    public void Release()
    {
        if (string.IsNullOrEmpty(address)) return;
        AddressableLoader.Release(address);
        address = null;
    }

    public void Cancel() 
    {
        version++;
    }

    /*
    Usage
        private readonly AddressableBinding<Sprite> binding = new();
        private int version;

        public async Task SetAsync(string address) 
        {
            int versionAux = ++version;

            var task = binding.LoadAsync(address);
            var asset = await task;

            if (versionAux != version) return;

            ui.sprite = asset;
        }

    On Clear
        binding.Cancel();
        binding.Release();
        version++;
    */
}
