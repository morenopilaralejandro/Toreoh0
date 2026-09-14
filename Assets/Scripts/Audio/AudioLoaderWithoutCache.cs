using UnityEngine;
using System.Threading.Tasks;

public class AudioLoaderWithoutCache : IAudioLoader 
{    
    public void Initialize(CacheLruAudioClip cache) { }

    public async Task<AudioClip> LoadAudioAsync(string address) => await AddressableLoader.LoadAssetAsync<AudioClip>(address);
    public void Release(string address) => AddressableLoader.Release(address);
    public void Clear() { }
}
