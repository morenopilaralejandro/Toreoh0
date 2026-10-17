using UnityEngine;
using System;
using Aremoreno.Enums.UI;

public static class UIEvents 
{
    // memory
    public static event Action<GameObject> OnSelectableSelected;
    public static void RaiseSelectableSelected(GameObject go) 
        => OnSelectableSelected?.Invoke(go);

    // menu
    public static event Action<Menu> OnMenuOpened;
    public static void RaiseMenuOpened(Menu menu)
        => OnMenuOpened?.Invoke(menu);

    public static event Action<Menu> OnMenuClosed;
    public static void RaiseMenuClosed(Menu menu)
        => OnMenuClosed?.Invoke(menu);

    public static event Action OnMenuClosedAll;
    public static void RaiseMenuClosedAll()
        => OnMenuClosedAll?.Invoke();

    // menu open requested
    public static event Action OnMenuTestOpenRequested;
    public static void RaiseMenuTestOpenRequested()
        => OnMenuTestOpenRequested?.Invoke();

    public static event Action OnMenuSideOpenRequested;
    public static void RaiseMenuSideOpenRequested()
        => OnMenuSideOpenRequested?.Invoke();

    public static event Action OnMenuDebugWorldOpenRequested;
    public static void RaiseMenuDebugWorldOpenRequested()
        => OnMenuDebugWorldOpenRequested?.Invoke();

    // selector open requested
    public static event Action<
        ISelectorSource<ItemStorageSlot>, 
        ISelectorActionClick<ItemStorageSlot>, 
        ISelectorFilter<ItemStorageSlot>
    > OnSelectorItemStorageSlogBagOpenRequested;
    public static void RaiseSelectorItemStorageSlogBagOpenRequested(
        ISelectorSource<ItemStorageSlot> source, 
        ISelectorActionClick<ItemStorageSlot> actionClick, 
        ISelectorFilter<ItemStorageSlot> filter)
        => OnSelectorItemStorageSlogBagOpenRequested?
            .Invoke(source, actionClick, filter);

    // overview
    public static event Action<Item> OnItemOverviewUpdateRequested;
    public static void RaiseItemOverviewUpdateRequested(Item item)
        => OnItemOverviewUpdateRequested?.Invoke(item);
}
