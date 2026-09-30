using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ScrollViewAuto : MonoBehaviour 
{
    [Header("References")]
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private RectTransform viewport;
    [SerializeField] private RectTransform content;

    [Header("Settings")]
    [SerializeField] private float scrollSpeed = 8f;
    [SerializeField] private float padding = 10f;
    [SerializeField] private bool isInstant = false;

    private GameObject lastSelected;
    private bool isScrolling;
    private Vector2 targetAnchoredPos;
    private bool isActive;

    private float contentHeight;
    private float contentWidth;
    private float viewportHeight;
    private float viewportWidth;
    private float viewportHalfHeight;
    private float viewportHalfWidth;
    private float viewportTop;
    private float viewportBottom;
    private float viewportRight;
    private float viewportLeft;

    public const int MAX_CHILD_DEPTH = 4;

    // lifecycle
    private void Awake() 
    {
        contentHeight = content.rect.height;
        contentWidth = content.rect.width;
        viewportHeight = viewport.rect.height;
        viewportWidth = viewport.rect.width;
        viewportHalfHeight = viewportHeight * 0.5f;
        viewportHalfWidth = viewportWidth * 0.5f;
        viewportTop = viewport.rect.yMax - padding;
        viewportBottom = viewport.rect.yMin + padding;
        viewportRight = viewport.rect.xMax - padding;
        viewportLeft = viewport.rect.xMin + padding;
    }

    private void LateUpdate() 
    {
        if (!isActive) return;
        GameObject selected = EventSystem.current?.currentSelectedGameObject;
        if (selected != lastSelected) 
        {
            lastSelected = selected;
            HandleSelectionChanged(selected);
        }
        if(isInstant || !isScrolling) return;
        Vector2 next = Vector2.Lerp(content.anchoredPosition, targetAnchoredPos, Time.unscaledDeltaTime * scrollSpeed);
        if (Vector2.SqrMagnitude(next - targetAnchoredPos) < 0.1f) 
        {
            content.anchoredPosition = targetAnchoredPos;
            isScrolling = false;
        }
        else
        {
            content.anchoredPosition = next;
        }
    }

    // isActive
    public void Activate() 
    {
        isActive = true;
        StartCoroutine(DelayedReset());
    }

    public void Deactivate() 
    {
        isActive = false;
        isScrolling = false;
        lastSelected = null;
    }

    private IEnumerator DelayedReset() 
    {
        yield return null;
        lastSelected = null;
    }

    // selection
    private void HandleSelectionChanged(GameObject selected) 
    {
        if (selected == null) return;
        if (!IsChildOfContent(selected.transform)) return;
        RectTransform selectedRectTransform = selected.transform as RectTransform;
        if (selectedRectTransform == null) return;
        Canvas.ForceUpdateCanvases();
        ComputeAndApplyScroll(selectedRectTransform);
    }
    
    // scroll
    private void ComputeAndApplyScroll(RectTransform selectedRectTransform) 
    {
        Vector2 selectedCenterInViewPort = viewport.InverseTransformPoint(selectedRectTransform.TransformPoint(selectedRectTransform.rect.center));
        float selectedHalfHeight = selectedRectTransform.rect.height * 0.5f;
        float selectedHalfWidth = selectedRectTransform.rect.width * 0.5f;
        Vector2 newPosition = content.anchoredPosition;
        bool hasChanged = true;

        if (scrollRect.vertical)
        {
            float selectedTop = selectedCenterInViewPort.y + selectedHalfHeight;
            float selectedBottom = selectedCenterInViewPort.y - selectedHalfHeight;
            if (selectedBottom < viewportBottom) 
                newPosition.y += viewportBottom - selectedBottom;
            else if (selectedTop > viewportTop)
                newPosition.y -= selectedTop - viewportTop;
            else
                hasChanged = false;
        }

        if (scrollRect.horizontal)
        {
            float selectedRight = selectedCenterInViewPort.x + selectedHalfWidth;
            float selectedLeft = selectedCenterInViewPort.x - selectedHalfWidth;
            if (selectedLeft < viewportLeft) 
                newPosition.x -= viewportLeft - selectedLeft;
            else if (selectedRight > viewportRight)
                newPosition.x += selectedRight - viewportRight;
            else
                hasChanged = false;
        }

        if (!hasChanged) return;
        ApplyScroll(ClampToContent(newPosition));
    }

    private Vector2 ClampToContent(Vector2 pos) 
    {
        if (scrollRect.vertical) 
        {
            float maxY = Mathf.Max(0f, contentHeight - viewportHeight);
            pos.y = Mathf.Clamp(pos.y, 0f, maxY);
        }

        if (scrollRect.horizontal) 
        {
            float maxX = Mathf.Max(0f, contentWidth - viewportHalfWidth);
            pos.x = Mathf.Clamp(pos.x, -maxX, 0f);
        }

        return pos;
    }

    private void ApplyScroll(Vector2 pos)
    {
        if (isInstant) 
        {
            content.anchoredPosition = pos;
            isScrolling = false;
        }
        else 
        {
            targetAnchoredPos = pos;
            isScrolling = true;
        }
    } 

    private bool IsChildOfContent(Transform t) 
    {
        Transform current = t;
        for (int i = 0; i < MAX_CHILD_DEPTH; i++)
        {
            if (current == null) return false;
            if (current == content) return true;
            current = current.parent;
        }
        return false;
    }

    public void ScrollTo(RectTransform rectTransform, bool isInstantForced = false) 
    {
        if (rectTransform == null) return;
        bool wasInstant = isInstant;
        if (isInstantForced) isInstant = true;
        ComputeAndApplyScroll(rectTransform);
        isInstant = wasInstant;
    }

    public void ResetToTop() 
    {
        content.anchoredPosition = Vector2.zero;
        isScrolling = false;
        lastSelected = null;
    }

    public void OnScroll(BaseEventData baseEventData) 
    {
        if (!isActive) return;
        isScrolling = false;
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        if (pointerEventData == null) return;
        scrollRect.OnScroll(pointerEventData);
        EventSystem.current?.SetSelectedGameObject(null);
        // lastSelected = EventSystem.current?.currentSelectedGameObject;
    }
}
