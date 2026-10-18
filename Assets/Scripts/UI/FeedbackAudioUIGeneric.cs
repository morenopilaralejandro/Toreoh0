using UnityEngine;
using UnityEngine.EventSystems;
using Aremoreno.Enums.UI;

public class FeedbackAudioUIGeneric : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IPointerUpHandler,
    IPointerClickHandler,
    IBeginDragHandler,
    IEndDragHandler,
    IDropHandler,
    ISelectHandler,
    ISubmitHandler
{
    [Header("EnabledFlag")]
    [SerializeField] private FeedbackAudioFlag enabledFlags;

    [Header("Sfx")]
    [SerializeField] private string pointerEnterSfx = "";
    [SerializeField] private string pointerExitSfx = "";
    [SerializeField] private string pointerDownSfx = "";
    [SerializeField] private string pointerUpSfx = "";
    [SerializeField] private string pointerClickSfx = "";
    [SerializeField] private string beginDragSfx = "";
    [SerializeField] private string endDragSfx = "";
    [SerializeField] private string dropSfx = "";
    [SerializeField] private string selectSfx = "sfx-ui_select";
    [SerializeField] private string submitSfx = "sfx-ui_tap";

    private void Play(FeedbackAudioFlag flag, string sfx)
    {
        if((enabledFlags & flag) == 0) return;
        if(string.IsNullOrEmpty(sfx)) return;
        _ = AudioManager.Instance.SfxUI.Play(sfx);
    }

    public void OnPointerEnter(PointerEventData e) => Play(FeedbackAudioFlag.PointerEnter, pointerEnterSfx);
    public void OnPointerExit(PointerEventData e) => Play(FeedbackAudioFlag.PointerExit, pointerExitSfx);
    public void OnPointerDown(PointerEventData e) => Play(FeedbackAudioFlag.PointerDown, pointerDownSfx);
    public void OnPointerUp(PointerEventData e) => Play(FeedbackAudioFlag.PointerUp, pointerUpSfx);
    public void OnPointerClick(PointerEventData e) => Play(FeedbackAudioFlag.Click, pointerClickSfx);
    public void OnBeginDrag(PointerEventData e) => Play(FeedbackAudioFlag.BeginDrag, beginDragSfx);
    public void OnEndDrag(PointerEventData e) => Play(FeedbackAudioFlag.EndDrag, endDragSfx);
    public void OnDrop(PointerEventData e) => Play(FeedbackAudioFlag.Drop, dropSfx);
    public void OnSelect(BaseEventData e) => Play(FeedbackAudioFlag.Select, selectSfx);
    public void OnSubmit(BaseEventData e) => Play(FeedbackAudioFlag.Submit, submitSfx);
}
