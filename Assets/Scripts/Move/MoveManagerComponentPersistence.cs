public class MoveManagerComponentPersistence
{
    private MoveManager MoveManager;

    public MoveManagerComponentPersistence(MoveManager MoveManager)
    {
        this.MoveManager = MoveManager;
    }

    public MoveManagerSaveData Export()
    {
        return new MoveManagerSaveData 
        {
            MoveManagerComponentStorageSaveData = MoveManager.MoveManagerComponentStorage.Export(),
        };
    }

    public void Import(SaveData saveData) 
    {
        MoveManager.MoveManagerComponentStorage.Import(saveData.MoveManagerSaveData.MoveManagerComponentStorageSaveData);
    }

    public void InitializeForNewGame() 
    {
        MoveManager.MoveManagerComponentStorage.InitializeForNewGame();
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
