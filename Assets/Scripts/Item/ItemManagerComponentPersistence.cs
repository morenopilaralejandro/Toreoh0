public class ItemManagerComponentPersistence
{
    private ItemManager itemManager;

    public ItemManagerComponentPersistence(ItemManager itemManager)
    {
        this.itemManager = itemManager;
    }

    public ItemManagerSaveData Export()
    {
        return new ItemManagerSaveData 
        {
            ItemManagerComponentStorageSaveData = itemManager.StorageComponent.Export()
            ItemManagerComponentCurrencySaveData = itemManager.CurrencyComponent.Export()
        };
    }

    public void Import(SaveData saveData) 
    {
        itemManager.StorageComponent.Import(saveData.ItemManagerSaveData.ItemManagerComponentStorageSaveData);
        itemManager.CurrencyComponent.Import(saveData.ItemManagerSaveData.ItemManagerComponentCurrencySaveData);
    }

    public void InitializeForNewGame() 
    {
        itemManager.StorageComponent.InitializeForNewGame();
        itemManager.CurrencyComponent.InitializeForNewGame();
    }

    // event
    public void Subscribe()
    {
        PersistenceEvents.OnGameLoadEnded += OnGameLoadEnded;
        PersistenceEvents.OnNewGameStarted += OnNewGameStarted;
    }

    public void Unsubscribe()
    {
        PersistenceEvents.OnGameLoadEnded -= OnGameLoadEnded;
        PersistenceEvents.OnNewGameStarted -= OnNewGameStarted;
    }

    private void OnGameLoadEnded(SaveData saveData) => Import(saveData);
    private void OnNewGameStarted() => InitializeForNewGame();
}
