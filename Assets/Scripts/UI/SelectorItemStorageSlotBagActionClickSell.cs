using Aremoreno.Enums.UI;
using Aremoreno.Enums.Item;

public class SelectorItemStorageSlotBagActionClickSell : ISelectorActionClick<ItemStorageSlot>
{
    private Shop shop;
    private CurrencyType currencyType = CurrencyType.Gold;

    public SelectorItemStorageSlotBagActionClickSell(Shop shop) 
    {
        this.shop = shop;
        if (shop != null) currencyType = shop.AttributesComponent.CurrencyType;
    }

    public void Execute(ItemStorageSlot obj, IMenuClosable menu)
    {
        if (!obj.Item.ShopComponent.IsSellable) return;
        UIEvents.RaiseMenuAmountPickerItemOpenRequested(
            AmountPickerMode.Sell,
            obj.Item,
            1,
            1,
            ItemManager.Instance.StorageComponent.GetItemCount(obj.Item),
            currencyType);
    }
}
