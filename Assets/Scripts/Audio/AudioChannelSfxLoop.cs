public class AudioChannelSfxLoop : AudioChannel 
{ 
    public overrider void SetVolume() => source.volume * config.FactorSfxLoopVolume;
}
