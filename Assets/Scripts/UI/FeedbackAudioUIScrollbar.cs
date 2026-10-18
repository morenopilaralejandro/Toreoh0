using UnityEngine;
using UnityEngine.UI;

public class FeedbackAudioUIScrollbar : MonoBehaviour
{
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private string valueChangedSfx = "sfx-ui_scroll";
    [SerializeField] private float threshold = 0.02f;
    private float lastValue;

    private void Awake() 
    {
        scrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
        lastValue = scrollbar.value;
    }

    private void OnDestroy() 
    {
        scrollbar?.onValueChanged.RemoveListener(OnScrollbarValueChanged);
    }

    private void OnScrollbarValueChanged(float floatValue) 
    {
        if (Mathf.Abs(floatValue - lastValue) < threshold) return;
        lastValue = floatValue;
        _ = AudioManager.Instance.SfxUI.Play(valueChangedSfx);
    }
}
