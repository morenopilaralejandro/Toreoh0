using UnityEngine;

public class AudioChannelSfxUI : AudioChannel 
{ 
    private float nextAllowedTime = 0f;

    public AudioChannelSfxUI(
        AudioConfig config,
        AudioSource source,
        IAudioLoader loader,
        IAudioPlayer player,
        bool isLoop) 
    : base(
        config,
        source,
        loader,
        player,
        isLoop) { }

    public override void Play(AudioClip clip)
    {
        float now = Time.unscaledTime;
        if(now < config.MinIntervalPerSfxUI) return;
        nextAllowedTime = now + config.MinIntervalPerSfxUI;
        player.Play(clip, source, isLoop : isLoop);
    }
}
