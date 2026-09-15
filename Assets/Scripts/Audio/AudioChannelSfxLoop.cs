using UnityEngine;

public class AudioChannelSfxLoop : AudioChannel 
{ 
    public AudioChannelSfxLoop(
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

    public override void SetVolume(float volume) => source.volume = volume * config.FactorSfxLoopVolume;
}
