public class AudioChannelSfxUI : AudioChannel 
{ 
    private float nextAllowedTime = 0f;

    public overrider void Play(AudioClip clip)
    {
        float now = Time.unscaledTime;
        if(now < config.MinIntervalPerSfxUI) return;
        nextAllowedTime = now + config.MinIntervalPerSfxUI;
        player.Play(clip, source, isLoop : isLoop);
    }
}
