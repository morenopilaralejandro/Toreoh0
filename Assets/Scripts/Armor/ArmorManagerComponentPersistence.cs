public class ArmorManagerComponentPersistence
{
    private ArmorManager ArmorManager;

    public ArmorManagerComponentPersistence(ArmorManager ArmorManager)
    {
        this.ArmorManager = ArmorManager;
    }

    public ArmorManagerSaveData Export()
    {
        return new ArmorManagerSaveData 
        {
            ArmorManagerComponentStorageSaveData = ArmorManager.ArmorManagerComponentStorage.Export(),
        };
    }

    public void Import(SaveData saveData) 
    {
        ArmorManager.ArmorManagerComponentStorage.Import(saveData.ArmorManagerSaveData.ArmorManagerComponentStorageSaveData);
    }

    public void InitializeForNewGame() 
    {
        ArmorManager.ArmorManagerComponentStorage.InitializeForNewGame();
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
