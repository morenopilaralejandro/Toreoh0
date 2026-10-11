using UnityEngine;
using UnityEngine.UI;

public class FeedbackAudioUIScrollRect : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private string valueChangedSfx = "sfx-ui_scroll";
    [SerializeField] private float threshold = 0.02f;
    private Vector2 lastPosition;

    private void Awake() 
    {
        scrollRect.onValueChanged.AddListener(OnScrollRectValueChanged);
        lastPosition = scrollRect.normalizedPosition;
    }

    private void OnDestroy() 
    {
        scrollRect?.onValueChanged.RemoveListener(OnScrollRectValueChanged);
    }

    private void OnScrollRectValueChanged(Vector2 pos) 
    {
        if ((pos - lastPosition).sqrMagnitude < threshold) return;
        lastPosition = pos;
        _ = AudioManager.Instance.SfxUI.Play(valueChangedSfx);
    }
}
