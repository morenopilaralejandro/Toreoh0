using UnityEngine;
using TMPro;
using Aremoreno.Enums.Input;
using Aremoreno.Enums.Item;
using Aremoreno.Enums.UI;

public class MenuAmountPickerItem : MenuAmountPicker
{
    //[Header("UI References")]
    [SerializeField] private TMP_Text textTotal;
    private AmountPickerMode amountPickerMode;
    private Item item;
    private CurrencyType currencyType;

    // Lifecycle

    // Input
    protected override void OnGainedInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputNavigation input)
    {
        if (input == InputNavigation.Back) OnButtonBackClicked();
    }

    public void OnButtonBackClicked() => RequestClose();

    public override void OnButtonConfirmClicked() 
    {
        switch (amountPickerMode) 
        {
            case AmountPickerMode.Buy:
                ItemManager.Instance.ProcessComponent.Buy(item, countCurrent, currencyType);
                break;
            case AmountPickerMode.Sell:
                ItemManager.Instance.ProcessComponent.Sell(item, countCurrent, currencyType);
                break;
        }
        base.OnButtonConfirmClicked();
    }

    // Logic
    protected override void ChangeCount(int delta) 
    {
        base.ChangeCount(delta);
        switch (amountPickerMode) 
        {
            case AmountPickerMode.Buy:
                textTotal.text = (countCurrent * item.ShopComponent.GetPriceBuy(currencyType)).ToString();
                break;
            case AmountPickerMode.Sell:
                textTotal.text = (countCurrent * item.ShopComponent.GetPriceSell(currencyType)).ToString();
                break;
        }
    }

    // Event
    protected override void OnEnable() 
    {
        base.OnEnable();
        UIEvents.OnMenuAmountPickerItemOpenRequested += OnMenuAmountPickerItemOpenRequested;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        UIEvents.OnMenuAmountPickerItemOpenRequested -= OnMenuAmountPickerItemOpenRequested;
    }

    private void OnMenuAmountPickerItemOpenRequested(AmountPickerMode amountPickerMode, Item item, int countCurrent, int countMin, int countMax, CurrencyType currencyType) 
    {
        base.countCurrent = countCurrent;
        base.countMin = countMin;
        base.countMax = countMax;

        this.amountPickerMode = amountPickerMode;
        this.item = item;
        this.currencyType = currencyType;

        ChangeCount(0);

        MenuManager.Instance.OpenMenu(this); 
    }
}
