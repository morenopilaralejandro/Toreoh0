using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class ScrollViewPoolAdapter<TListItem> where TListItem : MonoBehaviour
{
    private ScrollRect scrollRect;
    private ScrollViewAuto scrollAuto;
    private RectTransform rectTrasformLayout;

    public ObjectPoolCustomList<TListItem> Pool { get; private set; }
    public ScrollRect ScrollRect => scrollRect;

    public void Initialize(
        ScrollViewPoolAdapterUI uiScroll,
        ObjectPoolCustomListWrapperMonoBehaviourUI uiPool,
        Func<TListItem> createFunc,
        Action<TListItem> actionOnGet, 
        Action<TListItem> actionOnRelease,
        Action<TListItem> actionOnDestroy)
    {
        scrollRect = uiScroll.ScrollRect;
        scrollAuto = uiScroll.ScrollAuto;
        rectTrasformLayout = uiScroll.RectTrasformLayout;
        Pool = new ObjectPoolCustomList<TListItem>(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, uiPool.DefaultCapacity);
    }

    public void Clear() 
    {
        Pool.Dispose();
    }

    public void Populate<TData>(IEnumerable<TData> dataCollection, Action<TListItem, TData> bind) 
    {
        Clear();
        foreach (var data in dataCollection)
            bind(Pool.Get(), data);
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
