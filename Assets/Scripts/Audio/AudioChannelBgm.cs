using UnityEngine;

public class AudioChannelBgm : AudioChannel 
{ 
    public AudioChannelBgm(
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
