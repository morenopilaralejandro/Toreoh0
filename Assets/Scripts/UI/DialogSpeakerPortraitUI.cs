using UnityEngine;

public class DialogSpeakerPortraitUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private CharacterPortraitUISpeaker portrait;

    // Events
    private void OnEnable() 
    {
        DialogEvents.OnLineReady += OnLineReady;
    }

    private void OnDisable() 
    {
        DialogEvents.OnLineReady -= OnLineReady;
    }

    private void OnLineReady(DialogSerializableLine line, Speaker speaker) 
    {
        if (speaker.AppearanceComponent.HasPortrait)
            _ = portrait.SetAsync(speaker);
        else
            portrait.Clear();
    }

    public void Clear() 
    {
        portrait.Clear();
    }
}
