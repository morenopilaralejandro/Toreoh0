using UnityEngine;
using System.Threading.Tasks;

public interface IAudioLoader
{
    void Initialize(CacheLru<string, AudioClip> cache);
    Task<AudioClip> LoadAudioAsync(string address);
    void Release(string address);
    void Clear();
}
