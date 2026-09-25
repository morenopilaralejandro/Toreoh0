public class Speaker 
{
    public SpeakerComponentAttributes AttributesComponent { get; private set; }
    public SpeakerComponentLocalization LocalizationComponent { get; private set; }
    public SpeakerComponentAppearance AppearanceComponent { get; private set; }

    public Speaker(SpeakerData data) 
    {
        AttributesComponent = new SpeakerComponentAttributes(data);
        LocalizationComponent = new SpeakerComponentLocalization(data, this);
        AppearanceComponent = new SpeakerComponentAppearance(data);
    }
}
