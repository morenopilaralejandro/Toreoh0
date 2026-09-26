using Aremoreno.Enums.Dialog;

public class SpeakerComponentAppearance
{
    public string PortraitAddress { get; private set; }
    public Mood Mood { get; private set; }
    public bool HasPortrait { get; private set; }

    public SpeakerComponentAppearance(SpeakerData data, Speaker speaker)
    {
        Mood = EnumUtils.StringToEnum<Mood>(data.Mood);
        HasPortrait = true;
        switch(speaker.AttributesComponent.SpeakerType) 
        {
            case SpeakerType.Character:
                PortraitAddress = ""; // AddressableBuilder.Get x with mood
                break;
            case SpeakerType.Npc:
                PortraitAddress = ""; // AddressableBuilder.Get x with mood
                break;
            default:
                HasPortrait = false;
                break;
        }
    }
}
