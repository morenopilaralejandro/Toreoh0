using UnityEngine;
using UnityEngine.UI;

public class FeedbackAudioUIToggle : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private string onSfx = "";
    [SerializeField] private string offSfx = "";

    private void Awake() 
    {
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnDestroy() 
    {
        toggle?.onValueChanged.RemoveListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn) 
    {
        if (isOn)
            _ = AudioManager.Instance.SfxUI.Play(onSfx);    
        else
            _ = AudioManager.Instance.SfxUI.Play(offSfx);
    }
}
