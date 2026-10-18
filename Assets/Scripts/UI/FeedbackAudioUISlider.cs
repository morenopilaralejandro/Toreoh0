using UnityEngine;
using UnityEngine.UI;

public class FeedbackAudioUISlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private string valueChangedSfx = "sfx-ui_scroll";
    [SerializeField] private float stepValue = 0.05f;
    private float lastValue;

    private void Awake() 
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        lastValue = slider.value;
    }

    private void OnDestroy() 
    {
        slider?.onValueChanged.RemoveListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float floatValue) 
    {
        if (Mathf.Abs(floatValue - lastValue) < stepValue) return;
        lastValue = floatValue;
        _ = AudioManager.Instance.SfxUI.Play(valueChangedSfx);
    }
}
