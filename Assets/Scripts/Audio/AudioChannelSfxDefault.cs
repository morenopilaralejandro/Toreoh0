using UnityEngine;

public class AudioChannelSfxDefault : AudioChannel 
{ 
    public AudioChannelSfxDefault(
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
}
