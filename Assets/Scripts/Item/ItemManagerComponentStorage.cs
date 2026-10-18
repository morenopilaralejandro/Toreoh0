using System.Collections.Generic;
using Aremoreno.Enums.Item;

public class ItemManagerComponentStorage
{
    //fields
    private List<ItemStorageSlot> listMaterial = new();
    private List<ItemStorageSlot> listMisc = new();
    private List<ItemStorageSlot> listImportant = new();
    private List<ItemStorageSlot> listRecovery = new();
    private List<ItemStorageSlot> listMove = new();

    private Dictionary<ItemCategory, List<ItemStorageSlot>> dictCategory;
    public IReadOnlyDictionary<ItemCategory, List<ItemStorageSlot>> DictCategory => dictCategory;
    private ItemStorageSlot cachedSlot;
    private ItemConfig config;

    // constructor
    public ItemManagerComponentStorage(ItemConfig config)
    {
        this.config = config;
        dictCategory = new Dictionary<ItemCategory, List<ItemStorageSlot>>
        {
            { ItemCategory.Material, listMaterial },
            { ItemCategory.Misc, listMisc },
            { ItemCategory.Important, listImportant },
            { ItemCategory.Recovery, listRecovery },
            { ItemCategory.Move, listMove }
        };
    }

    // helper
    private void SetCachedSlot(Item item) => SetCachedSlot(item.AttributesComponent.ItemId, item.AttributesComponent.ItemCategory);
    private void SetCachedSlot(string itemId, ItemCategory itemCategory) 
    {
        cachedSlot = null;
        for(int i = 0; i < dictCategory[itemCategory].Count; i++) 
        {
            if (dictCategory[itemCategory][i].Item.AttributesComponent.ItemId == itemId)
            {
                cachedSlot = dictCategory[itemCategory][i];
                break;
            }
        }
    }

    private void InsertSlot(Item item, int count)
    {
        cachedSlot = new ItemStorageSlot 
        {
            Item = item,
            Count = count
        };
        dictCategory[item.AttributesComponent.ItemCategory].Add(cachedSlot);
        SortCategoryByItemId(item.AttributesComponent.ItemCategory);
    }

    public void SortCategoryByItemId(ItemCategory itemCategory) => SortByItemId(dictCategory[itemCategory]);
    public void SortByItemId(List<ItemStorageSlot> list) => list.Sort((x, y) => 
        x.Item.AttributesComponent.ItemId.CompareTo(
        y.Item.AttributesComponent.ItemId));
    public void SortAllByItemId() 
    {
        foreach (var list in DictCategory.Values) 
            SortByItemId(list);
    }

    // add
    public void Add(ItemData itemData, int count = 1) => Add(ItemFactory.Create(itemData), count);
    public void Add(string itemId, int count = 1) => Add(ItemFactory.CreateById(itemId), count);
    public void Add(Item item, int count = 1)
    {
        if(TryAddToSystem(item)) return;
        SetCachedSlot(item);
        if (cachedSlot == null)
            InsertSlot(item, count);
        else
            cachedSlot.AddCount(count);
        ItemEvents.RaiseStorageUpdated();
    }

    private bool TryAddToSystem(Item item) 
    {
        // TODO add to respective manager storage
        // TODO add recipe to recipe tracker
        switch (item)
        {
            case ItemRecipe itemRecipe:
                return true;
            case ItemCharacter itemCharacter:
                return true;
            case ItemWing itemWing:
                return true;
            case ItemWeapon ItemWeapon:
                return true;
            case ItemArmor itemArmor:
                return true;
            default:
                return false;
        }
    }

    // remove
    public void Remove(ItemData itemData, int count = 1) => Remove(ItemFactory.Create(itemData), count);
    public void Remove(string itemId, int count = 1) => Remove(ItemFactory.CreateById(itemId), count);
    public void Remove(Item item, int count = 1) 
    {
        SetCachedSlot(item);
        if (cachedSlot == null) return;
        cachedSlot.RemoveCount(count);
        if (cachedSlot.Count <= 0)
            dictCategory[item.AttributesComponent.ItemCategory].Remove(cachedSlot);
        ItemEvents.RaiseStorageUpdated();
    }

    // query
    public List<ItemStorageSlot> GetItemsByCategory(ItemCategory itemCategory) => dictCategory[itemCategory];
    public bool HasItem(string itemId) => HasItem(ItemFactory.CreateById(itemId));
    public bool HasItem(Item item) => GetItemCount(item) > 0;
    public bool HasEnoughOfItem(string itemId, int amount) => HasEnoughOfItem(ItemFactory.CreateById(itemId), amount);
    public bool HasEnoughOfItem(Item item, int amount) => GetItemCount(item) >= amount;
    public int GetItemCount(string itemId) => GetItemCount(ItemFactory.CreateById(itemId));
    public int GetItemCount(Item item)
    {
        SetCachedSlot(item);
        if (cachedSlot == null)
            return 0;
        else
            return cachedSlot.Count;
    }

    // persistence
    public void Clear()
    {
        foreach(var list in dictCategory.Values)
            list.Clear();
    }

    public void InitializeForNewGame()
    {
        Clear();
        if (DebugUtils.IsDevBuild && config.IsDebugStorage)
            AddFromDatabase();
        else
            AddFromDefaultConfig();
    }

    private void AddFromDatabase()
    {
        foreach (var itemData in DatabaseManager.Instance.DatabaseRegistry.ItemData.Data.Values)
            Add(itemData, itemData.MaxStack);
    }

    private void AddFromDefaultConfig()
    {
        foreach (var data in config.ListStartingItemData)
            Add(ItemFactory.Create(data), data.MaxStack);
    }

    public ItemManagerComponentStorageSaveData Export() 
    {
        ItemManagerComponentStorageSaveData saveData = new();
        saveData.ListItemStorageSlotSaveData = new ();
        foreach (var list in DictCategory.Values)
            foreach (var slot in list)
                saveData.ListItemStorageSlotSaveData.Add(
                    new ItemStorageSlotSaveData 
                    {
                        ItemId = slot.Item.AttributesComponent.ItemId,
                        ItemCategory = slot.Item.AttributesComponent.ItemCategory,
                        Count = slot.Count
                    }
                );
        return saveData;
    }

    public void Import(ItemManagerComponentStorageSaveData saveData) 
    {
        Clear();
        foreach (var saveDataItemStorageSlot in saveData.ListItemStorageSlotSaveData)
        {
            Item item = ItemFactory.CreateById(saveDataItemStorageSlot.ItemId);
            ItemStorageSlot slot = new ItemStorageSlot 
            {
                Item = item, 
                Count = saveDataItemStorageSlot.Count
            };
            dictCategory[saveDataItemStorageSlot.ItemCategory].Add(slot);
        }
        SortAllByItemId();
    }
}
