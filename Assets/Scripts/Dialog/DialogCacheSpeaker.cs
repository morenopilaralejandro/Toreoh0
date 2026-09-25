public class DialogCacheSpeaker
{
    private CacheLru<string, Speaker> cache;
    private Speaker speaker = null;
    
    public void Initialize(DialogConfig config) 
    {
        cache = new CacheLru<string, Speaker>(config.CacheSpeakerCapacity);
    }

    public Speaker GetSpeaker(SpeakerData data) 
    {
        if (TryGet(data.CompoundKey, out speaker)) return speaker;
        speaker = new Speaker(data);
        Add(speaker.AttributesComponent.SpeakerCompoundKey, speaker);
        return speaker;
    }

    private void Add(string compoundKey, Speaker speaker) => cache.Add(compoundKey, speaker);
    private bool TryGet(string compoundKey, out Speaker speaker) => cache.TryGet(compoundKey, out speaker);
    private bool Remove(string compoundKey) => cache.Remove(compoundKey);

    public void Clear()
    {
        cache.Clear();
    }
}
