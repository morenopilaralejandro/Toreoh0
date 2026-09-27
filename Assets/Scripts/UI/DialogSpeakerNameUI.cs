using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSpeakerNameUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text textName;

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
        if (speaker.LocalizationComponent.HasDisplayName)
            textName.text = speaker.LocalizationComponent.ResolvedName;
        else
            textName.text = string.Empty;
    }
}
