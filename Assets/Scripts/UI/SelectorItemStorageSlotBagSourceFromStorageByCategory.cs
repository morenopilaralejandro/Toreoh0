using System.Collections.Generic;
using Aremoreno.Enums.Item;

public class SelectorItemStorageSlotBagSourceFromStorageByCategory : ISelectorSource<ItemStorageSlot>
{
    public ItemCategory ItemCategory;
    
    public SelectorItemStorageSlotBagSourceFromStorageByCategory() {}
    public SelectorItemStorageSlotBagSourceFromStorageByCategory(ItemCategory itemCategory)
    {
        ItemCategory = itemCategory;
    }

    public void SetItemCategory(ItemCategory itemCategory) => ItemCategory = itemCategory;

    public IEnumerable<ItemStorageSlot> Enumerate() 
        => ItemManager.Instance.StorageComponent.GetItemsByCategory(ItemCategory);
}
