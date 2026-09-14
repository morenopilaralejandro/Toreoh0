using UnityEngine;

public interface IAudioPlayer 
{
    void Play(AudioClip clip, AudioSource source, bool isLoop = false);
    void Stop(AudioSource source);
}
