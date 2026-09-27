public class DialogCacheSpeaker
{
    private CacheLru<string, Speaker> cache;
    private Speaker speaker = null;
    public Speaker CurrentSpeaker => speaker;

    public void Initialize(DialogConfig config) 
    {
        cache = new CacheLru<string, Speaker>(config.CacheSpeakerCapacity);
    }

    public void CacheCurrentSpeaker(SpeakerData data) 
    {
        if (TryGet(data.SpeakerCompoundKey, out speaker)) return;
        speaker = new Speaker(data);
        Add(speaker.AttributesComponent.SpeakerCompoundKey, speaker);
    }

    private void Add(string compoundKey, Speaker speaker) => cache.Add(compoundKey, speaker);
    private bool TryGet(string compoundKey, out Speaker speaker) => cache.TryGet(compoundKey, out speaker);
    private bool Remove(string compoundKey) => cache.Remove(compoundKey);

    public void Clear()
    {
        cache.Clear();
    }
}
