using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollRectForwarder : MonoBehaviour,
    IScrollHandler,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler,
    IInitializePotentialDragHandler
{
    [SerializeField] private ScrollRect scrollRect;

    public void SetScrollRect(ScrollRect scrollRect) => this.scrollRect = scrollRect;

    public void OnScroll(PointerEventData e) 
    {
        if (scrollRect != null) scrollRect.OnScroll(e);
    }

    public void OnBeginDrag(PointerEventData e) 
    {
        if (scrollRect != null) scrollRect.OnBeginDrag(e);
    }

    public void OnDrag(PointerEventData e) 
    {
        if (scrollRect != null) scrollRect.OnDrag(e);
    }

    public void OnEndDrag(PointerEventData e) 
    {
        if (scrollRect != null) scrollRect.OnEndDrag(e);
    }

    public void OnInitializePotentialDrag(PointerEventData e) 
    {
        if (scrollRect != null) scrollRect.OnInitializePotentialDrag(e);
    }
}
