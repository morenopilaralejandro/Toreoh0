using Aremoreno.Enums.Dialog;

public class SpeakerComponentAppearance
{
    public string PortraitAddress { get; private set; }
    public Mood Mood { get; private set; }

    public SpeakerComponentAppearance(SpeakerData data)
    {
        Mood = EnumUtils.StringToEnum<Mood>(data.Mood);
        /*
        switch(SpeakerType) 
        {
            case SpeakerType.Character:
                PortraitAddress = AddressableBuilder.Get x with mood
                break;
            case SpeakerType.Npc:
                PortraitAddress = AddressableBuilder.Get x
                break;
        }
        */
    }
}
