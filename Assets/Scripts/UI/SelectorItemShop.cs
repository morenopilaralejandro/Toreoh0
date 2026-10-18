using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Aremoreno.Enums.Input;
using Aremoreno.Enums.Item;

public class SelectorItemShop : Selector<Item, SelectorItemShopListItem>
{
    // fields
    [Header("IU")]
    [SerializeField] private CurrencyUI currencyUI;
    [SerializeField] private TMP_Text textName;

    // override
    public override void OnOpened() 
    {
        currencyUI.SetData();
        if (source is SelectorItemShopSource selectorItemShopSource)
            textName.text = selectorItemShopSource.Shop.LocalizationComponent.ShopName;
        UIEvents.RaiseItemOverviewUpdateRequested(null);
        base.OnOpened();
    }

    // input
    protected override void OnGainedInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputNavigation input)
    {
        if (input == InputNavigation.Back) OnButtonBackClicked();
    }

    public void OnButtonBackClicked() => RequestClose();
    public void OnButtonConfirmClicked() => OnClicked(lastSelectedElement);

    // event
    protected override void OnEnable()
    {
        base.OnEnable();
        UIEvents.OnSelectorItemShopOpenRequested += OnSelectorItemShopOpenRequested;
        ItemEvents.OnStorageUpdated += OnStorageUpdated;
    }

    protected override void OnDisable() 
    {
        base.OnDisable();
        UIEvents.OnSelectorItemShopOpenRequested -= OnSelectorItemShopOpenRequested;
        ItemEvents.OnStorageUpdated -= OnStorageUpdated;
    }

    private void OnSelectorItemShopOpenRequested(
        ISelectorSource<Item> source, 
        ISelectorActionClick<Item> actionClick, 
        ISelectorFilter<Item> filter) 
    {
        Open(source, actionClick, filter);
    }

    private void OnStorageUpdated() 
    {
        if (!menuManager.IsMenuOpened(this)) return;
        UIEvents.RaiseItemOverviewUpdateRequested(null);
        Refresh();
    }
}
