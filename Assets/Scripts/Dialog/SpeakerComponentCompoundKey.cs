public class SpeakerComponentCompoundKey
{
    public string CompoundKey { get; private set; }

    public SpeakerComponentCompoundKey(SpeakerData data)
    {
        CompoundKey = $"{data.SpeakerId}-{data.Mood}";
    }
}
