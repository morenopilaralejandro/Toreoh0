using UnityEngine;
using UnityEngine.UI;
using System;

public abstract class SelectorListItem<T> : MonoBehaviour, IScrollViewListItem 
{
    [SerializeField] protected ScrollRectForwarder scrollForwarder;
    public Button Button { get; private set; }
    public T Data { get; private set; }
    public ScrollRect ParentScrollRect { get; private set; }

    public event Action<SelectorListItem<T>> OnClicked;
    public event Action<SelectorListItem<T>> OnSelected;
    public event Action<SelectorListItem<T>> OnPointerEntered;

    public void SetScrollRect(ScrollRect scrollRect) 
    {
        ParentScrollRect = scrollRect;
        if (scrollForwarder != null) scrollForwarder.SetScrollRect(scrollRect);
    }

    public virtual void SetData(T data) 
    {
        Data = data;
        // call base
    }

    public virtual void Clear() 
    {
        // call base
        Data = default;
        ClearListeners();
    }

    private void ClearListeners() 
    {
        OnClicked = null;
        OnSelected = null;
        OnPointerEntered = null;
    }

    // unity editor click and trigger
    public virtual void OnListItemClicked() => OnClicked?.Invoke(this);
    public virtual void OnListItemSelected() => OnSelected?.Invoke(this);
    public virtual void OnListItemPointerEnter() => OnPointerEntered?.Invoke(this);
}
