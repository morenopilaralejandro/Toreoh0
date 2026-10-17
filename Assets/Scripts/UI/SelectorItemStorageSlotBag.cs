using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Aremoreno.Enums.Input;
using Aremoreno.Enums.Item;

public class SelectorItemStorageSlotBag : Selector<ItemStorageSlot, SelectorItemStorageSlotBagListItem>
{
    // fields
    [Header("IU")]
    [SerializeField] private TMP_Text textGold;
    [SerializeField] private ItemConfig config;

    private int currentItemCategoryIndex = 0;
    private Dictionary<ItemCategory, int> dictSelectedIndex = new ();
    private ItemCategory itemCategoryPrevious;

    // override
    protected override void Awake() 
    {
        itemCategoryPrevious = config.ItemCategoryDefaultBag;
        foreach (var itemCategory in config.ItemCategoryOrderBag)
            dictSelectedIndex[itemCategory] = 0;
        base.Awake();
    }

    public override void Show() 
    {
        source = new SelectorItemStorageSlotBagSourceFromStorageByCategory(itemCategoryPrevious);
        base.Show();
    }

    public override void OnOpened() 
    {
        textGold.text = ItemManager.Instance.CurrencyComponent.Get(CurrencyType.Gold).ToString();
        UIEvents.RaiseItemOverviewUpdateRequested(null);
        base.OnOpened();
    }

    public override void OnClosed() 
    {
        if (source is SelectorItemStorageSlotBagSourceFromStorageByCategory sourceItemCatrory)
            itemCategoryPrevious = sourceItemCatrory.ItemCategory;
        dictSelectedIndex[itemCategoryPrevious] = GetSelectedIndex();
        currentItemCategoryIndex = GetOrderIndex(itemCategoryPrevious);
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
        RefreshBag(config.ItemCategoryOrderBag[currentItemCategoryIndex]);
    }

    public void OnButtonShortcutBagPreviousClicked()
    {
        currentItemCategoryIndex--;
        if (currentItemCategoryIndex < 0)
            currentItemCategoryIndex = config.ItemCategoryOrderBag.Length - 1;
        RefreshBag(config.ItemCategoryOrderBag[currentItemCategoryIndex]);
    }

    public void OnButtonCategoryRecoveryClicked() => RefreshBag(ItemCategory.Recovery);
    public void OnButtonCategoryMoveClicked() => RefreshBag(ItemCategory.Move);
    public void OnButtonCategoryMaterialClicked() => RefreshBag(ItemCategory.Material);
    public void OnButtonCategoryMiscClicked() => RefreshBag(ItemCategory.Misc);
    public void OnButtonCategoryImportantClicked() => RefreshBag(ItemCategory.Important);

    // helper
    private int GetOrderIndex(ItemCategory itemCategory) => System.Array.IndexOf(config.ItemCategoryOrderBag, itemCategory);

    // logic

    private void RefreshBag(ItemCategory itemCategory)
    {
        if (!menuManager.IsMenuOpened(this)) return;
    }

    // event
    protected override void OnEnable()
    {
        base.OnEnable();
        UIEvents.OnSelectorItemStorageSlogBagOpenRequested += OnSelectorItemStorageSlogBagOpenRequested;
        ItemEvents.OnStorageUpdated += OnStorageUpdated;
        ItemEvents.OnCurrencyUpdated += OnCurrencyUpdated;
    }

    protected override void OnDisable() 
    {
        base.OnDisable();
        UIEvents.OnSelectorItemStorageSlogBagOpenRequested -= OnSelectorItemStorageSlogBagOpenRequested;
        ItemEvents.OnStorageUpdated -= OnStorageUpdated;
        ItemEvents.OnCurrencyUpdated -= OnCurrencyUpdated;
    }

    private void OnSelectorItemStorageSlogBagOpenRequested(
        ISelectorSource<ItemStorageSlot> source, 
        ISelectorActionClick<ItemStorageSlot> actionClick, 
        ISelectorFilter<ItemStorageSlot> filter) 
    {
        Open(source, actionClick, filter);
    }

    private void OnStorageUpdated() 
    {
        if (!menuManager.IsMenuOpened(this)) return;
        RefreshBag(itemCategoryPrevious);
    }

    private void OnCurrencyUpdated(CurrencyType currencyType, int count) 
    {
        if (!menuManager.IsMenuOpened(this)) return;
        switch (currencyType)
        {
            case CurrencyType.Gold:
                textGold.text = count.ToString();
                break;
        }
    }
}
