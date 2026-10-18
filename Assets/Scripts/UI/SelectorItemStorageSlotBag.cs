using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Aremoreno.Enums.Input;
using Aremoreno.Enums.Item;

public class SelectorItemStorageSlotBag : Selector<ItemStorageSlot, SelectorItemStorageSlotBagListItem>
{
    // fields
    [Header("IU")]
    [SerializeField] private CurrencyUI currencyUI;
    [SerializeField] private ItemConfig config;

    private int currentItemCategoryIndex = 0;
    private Dictionary<ItemCategory, int> dictSelectedIndex = new ();

    // override
    protected override void Awake() 
    {
        currentItemCategoryIndex = GetOrderIndex(config.ItemCategoryDefaultBag);
        foreach (var itemCategory in config.ItemCategoryOrderBag)
            dictSelectedIndex[itemCategory] = 0;
        base.Awake();
    }

    public override void Show() 
    {
        source = new SelectorItemStorageSlotBagSourceFromStorageByCategory(GetOrderCategory(currentItemCategoryIndex));
        base.Show();
    }

    public override void OnOpened() 
    {
        currencyUI.SetData();
        UIEvents.RaiseItemOverviewUpdateRequested(null);
        base.OnOpened();
    }

    public override void OnClosed() 
    {
        dictSelectedIndex[GetOrderCategory(currentItemCategoryIndex)] = lastSelectedElementIndex;
        base.OnClosed();
    }

    // input
    protected override void OnGainedInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputNavigation input)
    {
        switch(input) 
        {
            case InputNavigation.Back:
                OnButtonBackClicked();
                break;
            case InputNavigation.ShortcutBagNext:
                OnButtonShortcutBagNextClicked();
                break;
            case InputNavigation.ShortcutBagPrevious:
                OnButtonShortcutBagPreviousClicked();
                break;
        }
    }

    public void OnButtonBackClicked() => RequestClose();

    public void OnButtonShortcutBagNextClicked()
    {
        currentItemCategoryIndex++;
        if (currentItemCategoryIndex >= config.ItemCategoryOrderBag.Length)
            currentItemCategoryIndex = 0;
        RefreshBag(GetOrderCategory(currentItemCategoryIndex));
    }

    public void OnButtonShortcutBagPreviousClicked()
    {
        currentItemCategoryIndex--;
        if (currentItemCategoryIndex < 0)
            currentItemCategoryIndex = config.ItemCategoryOrderBag.Length - 1;
        RefreshBag(GetOrderCategory(currentItemCategoryIndex));
    }

    public void OnButtonCategoryRecoveryClicked() => RefreshBag(ItemCategory.Recovery);
    public void OnButtonCategoryMoveClicked() => RefreshBag(ItemCategory.Move);
    public void OnButtonCategoryMaterialClicked() => RefreshBag(ItemCategory.Material);
    public void OnButtonCategoryMiscClicked() => RefreshBag(ItemCategory.Misc);
    public void OnButtonCategoryImportantClicked() => RefreshBag(ItemCategory.Important);

    public void OnButtonConfirmClicked()
    {
        OnClicked(lastSelectedElement);
    }

    // helper
    private int GetOrderIndex(ItemCategory itemCategory) => System.Array.IndexOf(config.ItemCategoryOrderBag, itemCategory);
    private ItemCategory GetOrderCategory(int index) => config.ItemCategoryOrderBag[index];

    // logic

    private void RefreshBag(ItemCategory itemCategory)
    {
        if (!menuManager.IsMenuOpened(this)) return;
        currentItemCategoryIndex = GetOrderIndex(itemCategory);
        source = new SelectorItemStorageSlotBagSourceFromStorageByCategory(itemCategory);
        Refresh();
    }

    // event
    protected override void OnEnable()
    {
        base.OnEnable();
        UIEvents.OnSelectorItemStorageSlotBagOpenRequested += OnSelectorItemStorageSlotBagOpenRequested;
        ItemEvents.OnStorageUpdated += OnStorageUpdated;
    }

    protected override void OnDisable() 
    {
        base.OnDisable();
        UIEvents.OnSelectorItemStorageSlotBagOpenRequested -= OnSelectorItemStorageSlotBagOpenRequested;
        ItemEvents.OnStorageUpdated -= OnStorageUpdated;
    }

    private void OnSelectorItemStorageSlotBagOpenRequested(
        ISelectorSource<ItemStorageSlot> source, 
        ISelectorActionClick<ItemStorageSlot> actionClick, 
        ISelectorFilter<ItemStorageSlot> filter) 
    {
        Open(source, actionClick, filter);
    }

    private void OnStorageUpdated() 
    {
        if (!menuManager.IsMenuOpened(this)) return;
        UIEvents.RaiseItemOverviewUpdateRequested(null);
        RefreshBag(GetOrderCategory(currentItemCategoryIndex));
    }
}
