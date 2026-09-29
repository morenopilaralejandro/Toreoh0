using UnityEngine;

public class ScrollViewAuto : MonoBehaviour 
{
    [Header("References")]
    [SerializeField] private ScrollRect scorllRect;
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

    private readonly const MAX_CHILD_DEPTH = 4;

    // lifecycle
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

    private IEnumerable DelayedReset () 
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
        Cancas.ForceUpdateCanvases();
        ComputeAndApplyScroll(selectedRectTransform);
    }
    
    // scroll
    private void ComputeAndApplyScroll(RectTransform selectedRectTransform) 
    {
        Vector2 rectTrasformCenterInViewPort = viewport.InverseTransformPoint(selectedRectTransform.TransformPoint(selectedRectTransform.rect.center));
        float selectedHalfHeight = selectedRectTransform.rect.height * 0.5f;
        float selectedHalfWidth = selectedRectTransform.rect.width * 0.5f;
        float viewportHalfHeight = viewport.rect.height * 0.5f;
        float viewportHalfWidth = viewport.rect.width * 0.5f;
        Vector2 newPosition = content.anchoredPosition;
        bool hasChanged = false;

        if (scrollRect.vertical)
        {

        }

        if (scorllRect.horizontal)
        {

        }

        if (!hasChanged) return;
        ApplyScroll(ClampToContent(newPosition));
    }

    private Vector2 ClampToContent(Vector2 pos) 
    {
        float contentHeight = content.rect.height;
        float contentWidth = content.rect.width;
        float viewportHeight = viewport.rect.height;
        float viewportWidth = viewport.rect.width;

        if (scrollRect.vertical) 
        {
            float maxY = Mathf.Max(0f, contentHeight - viewportHalfHeight);
            pos.y = Mathf.Clamp(pos.y, 0f, maxY);
        }

        if (scrollRect.horizontal) 
        {
            float maxX = Mathf.Clamp(pos.x, -maxX, 0f);
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

    public void ScrollTo() 
    {

    }

    public void ResetToTop() 
    {

    }

    public void OnScroll(BaseEventData baseEventData) 
    {

    }
}
