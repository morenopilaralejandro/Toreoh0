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

    public IEnumerable<DialogSerializableChoice> Enumerate() 
        => ItemManager.Instance.StorageComponent.GetItemsByCategory(ItemCategory);
}
