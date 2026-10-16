using System.Collections.Generic;

public class ItemManagerComponentStorage
{
    //fields
    private List<ItemStorageSlot> listMaterial = new();
    private List<ItemStorageSlot> listMisc = new();
    private List<ItemStorageSlot> listImportant = new();
    private List<ItemStorageSlot> listRecovery = new();
    private List<ItemStorageSlot> listMove = new();

    private Dictionary<ItemStorageSlot, List<ItemStorageSlot>> dictCategory;
    public IReadOnlyDictionary<ItemStorageSlot, List<ItemStorageSlot>> DictCategory => dictCategory;
    private ItemStorageSlot cachedSlot;
    private ItemConfig config;

    // constructor
    public ItemManagerComponentStorage(ItemConfig config)
    {
        this.config = config;
        dictCategory = new Dictionary<ItemStorageSlot, List<ItemStorageSlot>>
        {
            { ItemCategory.Material, listMaterial },
            { ItemCategory.Mics, listMisc },
            { ItemCategory.Important, listImportant },
            { ItemCategory.Recovery, listRecovery },
            { ItemCategory.Move, listMove }
        };
    }

    // helper
    private void SetCachedSlot(Item item) => SetCachedSlot(item.ItemId, item.ItemCategory);
    private void SetCachedSlot(string itemId, ItemCategory itemCategory) 
    {
        cachedSlot = null;
        foreach(int i = 0; i < dictCategory[itemCategory].Count) 
        {
            if (dictCategory[itemCategory][i].Item.ItemId == item.ItemId)
            {
                cachedSlot = dictCategory[itemCategory][i];
                break;
            }
        }
    }

    private void InsertSlot(Item item, int count)
    {
        slot = new ItemStorageSlot(item, count);
        dictCategory[item.ItemCategory].Add(slot);
        SortCategoryByItemId(item.ItemCategory);
    }

    public void SortCategoryByItemId(ItemCategory itemCategory) => dictCategory[itemCategory] = SortByItemId(dictCategory[itemCategory]);
    public List<ItemStorageSlot> SortByItemId(List<ItemStorageSlot> list) => list.OrderBy(slot => slot.Item.ItemId);
    public void SortAllByItemId() 
    {
        foreach (var list in DictCategory.Values) 
            list = SortByItemId(list);
    }

    // add
    public void Add(ItemData itemData, int count = 1) => Add(ItemFactory.Create(itemData), count);
    public void Add(string itemId, int count = 1) => Add(ItemFactory.CreateById(itemId), count);
    public void Add(Item item, int count = 1)
    {
        if(TryAddToSystem(item)) return;
        SetCachedSlot();
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
        if (cachedSlot == null) return false;
        cachedSlot.RemoveCount(count);
        if (cachedSlot.Count <= 0)
            dictCategory[item.ItemCategory].Remove(cachedSlot);
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
        foreach (var itemData in DatabaseManager.Instace.DatabaseRegistry.ItemData.Data.Values)
            Add(itemData, data.MaxStack);
    }

    private void AddFromDefaultConfig()
    {
        foreach (var data in config.ListStartingItemData)
            Add(ItemFactory.Create(data), data.MaxStack);
    }

    public ItemManagerComponentStorageSaveData Export() 
    {
        ItemManagerComponentStorageSaveData saveData = new();
        saveData.ListItemStorageSlot = new ();
        foreach (var list in DictCategory.Values)
            foreach (var slot in list)
                saveData.ListItemStorageSlot.Add(
                    new ItemStorageSlotSaveData 
                    {
                        ItemId = slot.Item.ItemId,
                        ItemCategory = slot.Item.ItemCategory,
                        Count = slot.Count
                    }
                );
        return saveData;
    }

    public void Import(ItemManagerComponentStorageSaveData saveData) 
    {
        Clear();
        foreach (var saveDataItemStorageSlot in saveData.ListItemStorageSlot)
        {
            Item item = ItemFactory.CreateById(saveDataItemStorageSlot.ItemId);
            ItemStorageSlot slot = new ItemStorageSlot(item, saveDataItemStorageSlot.Count);
            dictCategory[saveDataItemStorageSlot.ItemCategory].Add(slot);
        }
        SortAllByItemId();
    }
}
