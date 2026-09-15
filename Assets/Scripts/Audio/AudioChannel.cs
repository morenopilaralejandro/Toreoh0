using UnityEngine;
using System.Threading.Tasks;

public abstract class AudioChannel
{
    protected AudioConfig config;
    protected AudioSource source;
    protected IAudioLoader loader;
    protected IAudioPlayer player;
    protected bool isLoop;

    public AudioChannel(
        AudioConfig config,
        AudioSource source,
        IAudioLoader loader,
        IAudioPlayer player,
        bool isLoop)
    {
        this.config = config;
        this.source = source;
        this.loader = loader;
        this.player = player;
        this.isLoop = isLoop;
    }

    public virtual void Play(AudioClip clip) => player.Play(clip, source, isLoop : isLoop);
    public virtual async Task Play(string address) => Play(await loader.LoadAudioAsync(address));

    public virtual void Stop() => player.Stop(source);
    public virtual void Stop(AudioClip clip) 
    {
        if (IsPlayingClip(clip)) Stop();
    }
    public virtual async void Stop(string address) 
    {
        if (await IsPlayingClip(address)) Stop(); 
    }

    public virtual void SetVolume(float volume) => source.volume = volume;
    public virtual AudioClip GetClip() => source.clip;
    public virtual bool IsPlaying() => source.isPlaying;
    public virtual bool IsPlayingClip(AudioClip clip) => source.isPlaying && source.clip == clip;
    public virtual async Task<bool> IsPlayingClip(string address) => IsPlayingClip(await loader.LoadAudioAsync(address));
    public virtual void Clear() => loader.Clear();
}
