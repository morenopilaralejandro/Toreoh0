using Aremoreno.Enums.Dialog;

public class SpeakerComponentAttributes 
{
    public string SpeakerId { get; private set; }
    public SpeakerType SpeakerType { get; private set; }

    public SpeakerComponentAttributes(SpeakerData data)
    {
        SpeakerId = data.SpeakerId;
        SpeakerType = EnumUtils.StringToEnum<SpeakerType>(data.SpeakerType);
    }
}
