using Aremoreno.Enums.Dialog;

public class SpeakerComponentAttributes 
{
    public string SpeakerId { get; private set; }
    public string SpeakerCompoundKey { get; private set; }
    public SpeakerType SpeakerType { get; private set; }

    public SpeakerComponentAttributes(SpeakerData data)
    {
        SpeakerId = data.SpeakerId;
        SpeakerCompoundKey = data.SpeakerCompoundKey;
        SpeakerType = EnumUtils.StringToEnum<SpeakerType>(data.SpeakerType);
    }
}
