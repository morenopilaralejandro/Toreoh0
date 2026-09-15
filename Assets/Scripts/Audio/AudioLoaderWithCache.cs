using UnityEngine;
using System.Threading.Tasks;

public class AudioLoaderWithCache : IAudioLoader 
{
    private CacheLru<string, AudioClip> cache;
    
    public void Initialize(CacheLru<string, AudioClip> cache) 
    {
        this.cache = cache;
    }

    public async Task<AudioClip> LoadAudioAsync(string address)
    {
        if (TryGet(address, out var clipCached)) return clipCached;
        var clip = await AddressableLoader.LoadAssetAsync<AudioClip>(address);
        Add(address, clip);
        return clip;
    }

    public void Release(string address) => AddressableLoader.Release(address);
    private void Add(string asset, AudioClip clip) => cache.Add(asset, clip);
    private bool TryGet(string address, out AudioClip clip) => cache.TryGet(address, out clip);
    private bool Remove(string address) => cache.Remove(address);

    public void Clear()
    {
        foreach (var address in cache.Keys)
            Release(address);
        cache.Clear();
    }
}
