using UnityEngine;
using TMPro;

public class FeedbackAudioUIDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private string valueChangedSfx = "sfx-ui_change";

    private void Awake() 
    {
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    private void OnDestroy() 
    {
        dropdown?.onValueChanged.RemoveListener(OnDropdownValueChanged);
    }

    private void OnDropdownValueChanged(int index) 
    {
        _ = AudioManager.Instance.SfxUI.Play(valueChangedSfx);
    }
}
