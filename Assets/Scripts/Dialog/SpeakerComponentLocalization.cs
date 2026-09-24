using Aremoreno.Enums.Dialog;

public class SpeakerComponentLocalization
{
    public string ResolvedName { get; private set; }
    public bool IsResolved { get; private set; }
    public bool HasDisplayName { get; private set; }

    public SpeakerComponentLocalization(SpeakerData data, Speaker speaker) 
    {
        ResolvedName = "";
        IsResolved = false;
        HasDisplayName = speaker.AttributesComponent.SpeakerType != SpeakerType.System;
    }

    public void SetResolvedName(string name) 
    { 
        ResolvedName = name;
        IsResolved = true;
    }
}
