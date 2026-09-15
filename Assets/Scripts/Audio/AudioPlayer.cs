using UnityEngine;

public class AudioPlayer : IAudioPlayer
{
    public void Play(AudioClip clip, AudioSource source, bool isLoop = false)
    {
        source.spatialBlend = 0f;
        if(isLoop) 
        {
            source.clip = clip;
            source.Play();
        }
        else 
        {
            source.PlayOneShot(clip);
        }
    }

    public void Stop(AudioSource source) 
    {
        if(!source.isPlaying) return;
        source.Stop();
        source.clip = null;
    }
}
