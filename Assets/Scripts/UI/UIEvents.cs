using UnityEngine;
using System;
using Aremoreno.Enums.Item;
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

    public static event Action<AmountPickerMode, Item, int, int, int, CurrencyType> OnMenuAmountPickerItemOpenRequested;
    public static void RaiseMenuAmountPickerItemOpenRequested(AmountPickerMode amountPickerMode, Item item, int countCurrent, int countMin, int countMax, CurrencyType currencyType)
        => OnMenuAmountPickerItemOpenRequested?.Invoke(amountPickerMode, item, countCurrent, countMin, countMax, currencyType);

    // selector open requested
    public static event Action<
        ISelectorSource<ItemStorageSlot>, 
        ISelectorActionClick<ItemStorageSlot>, 
        ISelectorFilter<ItemStorageSlot>
    > OnSelectorItemStorageSlotBagOpenRequested;
    public static void RaiseSelectorItemStorageSlotBagOpenRequested(
        ISelectorSource<ItemStorageSlot> source, 
        ISelectorActionClick<ItemStorageSlot> actionClick, 
        ISelectorFilter<ItemStorageSlot> filter)
        => OnSelectorItemStorageSlotBagOpenRequested?
            .Invoke(source, actionClick, filter);

    public static event Action<
        ISelectorSource<Item>, 
        ISelectorActionClick<Item>, 
        ISelectorFilter<Item>
    > OnSelectorItemShopOpenRequested;
    public static void RaiseSelectorItemShopOpenRequested(
        ISelectorSource<Item> source, 
        ISelectorActionClick<Item> actionClick, 
        ISelectorFilter<Item> filter)
        => OnSelectorItemShopOpenRequested?
            .Invoke(source, actionClick, filter);

    // overview
    public static event Action<Item> OnItemOverviewUpdateRequested;
    public static void RaiseItemOverviewUpdateRequested(Item item)
        => OnItemOverviewUpdateRequested?.Invoke(item);
}
