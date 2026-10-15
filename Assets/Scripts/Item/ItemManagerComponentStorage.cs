public class ItemManagerComponentStorage
{
    /*

    //fields
    private List<ItemStorageSlot> listMaterial = new();
    private List<ItemStorageSlot> listMisc = new();
    private List<ItemStorageSlot> listImportant = new();
    private List<ItemStorageSlot> listRecovery = new();
    private List<ItemStorageSlot> listMove = new();

    private Dictionary<ItemStorageSlot, List<ItemStorageSlot>> dictCategory;
    public IReadOnlyDictionary<ItemStorageSlot, List<ItemStorageSlot>> DictCategory => dictCategory;
    private ItemStorageSlot cachedSlot;

    // constructor
    public ItemManagerComponentStorage() 
    {
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

    public void SortCategoryByItemId(ItemCategory itemCategory) 
    {
        List<ItemStorageSlot> orderedList = dictCategory[itemCategory]
            .OrderBy(slot => slot.Item.ItemId)
        dictCategory[itemCategory] = orderedList;
    }


    // add

    // TODO add over load for item id and item data

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

    // buy

    void Buy(Item item, int amount, CurrencyType currencyType)

    void Sell(Item item, int amount, CurrencyType currencyType)

    // consume materials
    public bool HasEnoughMaterial(List<MaterialRequirement> materialRequirements)
    {
        foreach(var materialRequirement in materialRequirements)
            if (!HasEnoughOfItem(materialRequirement.ItemId, materialRequirement.Amount))
                return false;
        return true;
    }

    public void ConsumeMaterialRequirement(List<MaterialRequirement> materialRequirements)
    {
       foreach(var materialRequirement in materialRequirements)
            Remove(materialRequirement.ItemId, materialRequirement.Amount);
    }

    // use
    void UseItemOnCharacter() 
    {
        switch (item)
        {
            case ItemRecovery itemRecovery:
                break;
            case ItemMove itemMove:
                break;
        }
    }

    // persistence
    public void Clear()
    {
        foreach(var list in dictCategory.Values)
            list.Clear();
    }

    public void InitializeOnNewGame()
    {
        Clear();

        debug
        addAFromDatabase
        addFromDefaultConfig
    }

    private void AddFromDatabase()
    {
        foreach (var itemData in DatabaseManager.Instace.DatabaseRegistry.ItemData.Data.Values)
            Add(itemData, data.MaxStack);
    }

    private void AddFromDefaultConfig()
    {
        foreach (var data in config.ListDefaultItemData)
            Add(ItemFactory.Create(data), data.MaxStack);
    }

    public ItemManagerComponentStorageSaveData Export() 
    {
        ItemManagerComponentStorageSaveData saveData = new();
        saveData.ListStorageSlot = new ();
        foreach (var list in DictCategory.Values)
            foreach (var slot in list)
                saveData.ListStorageSlot.Add(
                    new ItemStorageSlotSaveData 
                    {
                        ItemId = slot.Item.ItemId,
                        ItemCategory = slot.Item.ItemCategory,
                        Count = slot.Count
                    }
                );
        return saveData.
    }

    public void Import(ItemManagerComponentStorageSaveData saveData) 
    {
        Clear();
        foreach (var saveDataItemStorageSlot in saveData.ListStorageSlot)
            Add()
    }



    */
}
