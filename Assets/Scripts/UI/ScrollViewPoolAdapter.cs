using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class ScrollViewPoolAdapter<TListItem> : MonoBehaviour where TListItem : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private ScrollViewAuto scrollAuto;
    [SerializeField] private RectTransform rectTrasformLayout;

    public ObjectPoolCustomListWrapperMonoBehaviour<TListItem> PoolWrapper { get; private set; }

    public void Initialize(Action<TListItem> actionOnGet, Action<TListItem> actionOnRelease) 
    {
        PoolWrapper.Initialize(actionOnGet, actionOnRelease);
    }

    public void Clear() 
    {
        PoolWrapper.Pool.Dispose();
    }

    public void Populate<TData>(IEnumerable<TData> dataCollection, Action<TListItem, TData> bind) 
    {
        Clear();
        foreach (var data in dataCollection)
            bind(PoolWrapper.Pool.Get(), data);
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTrasformLayout);
    }

    public void SetScrollActive(bool isActive) 
    {
        if (isActive)
            ScrollActivate();
        else
            ScrollDeactivate();
    }

    private void ScrollActivate() 
    {
        if (scrollAuto == null) return;
        scrollAuto.Activate();
        scrollAuto.ResetToTop();
    }

    private void ScrollDeactivate() 
    {
        if (scrollAuto == null) return;
        scrollAuto.Deactivate();
    }
}
