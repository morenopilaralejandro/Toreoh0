using UnityEngine;
using Aremoreno.Enums.UI;
using Aremoreno.Enums.Item;

public class SelectorItemShopActionClickBuy : ISelectorActionClick<Item>
{
    private Shop shop;

    public SelectorItemShopActionClickBuy(Shop shop) 
    {
        this.shop = shop;
    }

    public void Execute(Item obj, IMenuClosable menu)
    {
        CurrencyType currencyType = shop.AttributesComponent.CurrencyType;
        int price = obj.ShopComponent.GetPriceBuy(currencyType);

        bool canAffordOne = ItemManager.Instance.CurrencyComponent.HasEnoughOfCurrency(currencyType, price);

        if (!canAffordOne) return;
        int money = ItemManager.Instance.CurrencyComponent.Get(currencyType);
        int countMax = Mathf.FloorToInt(money / price);
        if (countMax > obj.InventoryComponent.MaxStack) countMax = obj.InventoryComponent.MaxStack;
        UIEvents.RaiseMenuAmountPickerItemOpenRequested(AmountPickerMode.Buy, obj, 1, 1, countMax, currencyType);
    }
}
