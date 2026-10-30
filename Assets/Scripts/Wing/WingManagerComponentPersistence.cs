public class WingManagerComponentPersistence
{
    private WingManager WingManager;

    public WingManagerComponentPersistence(WingManager WingManager)
    {
        this.WingManager = WingManager;
    }

    public WingManagerSaveData Export()
    {
        return new WingManagerSaveData 
        {
            WingManagerComponentStorageSaveData = WingManager.WingManagerComponentStorage.Export(),
        };
    }

    public void Import(SaveData saveData) 
    {
        WingManager.WingManagerComponentStorage.Import(saveData.WingManagerSaveData.WingManagerComponentStorageSaveData);
    }

    public void InitializeForNewGame() 
    {
        WingManager.WingManagerComponentStorage.InitializeForNewGame();
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
