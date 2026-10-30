public class TeamManagerComponentPersistence
{
    private TeamManager TeamManager;

    public TeamManagerComponentPersistence(TeamManager TeamManager)
    {
        this.TeamManager = TeamManager;
    }

    public TeamManagerSaveData Export()
    {
        return new TeamManagerSaveData 
        {
            TeamManagerComponentStorageSaveData = TeamManager.StorageComponent.Export(),
        };
    }

    public void Import(SaveData saveData) 
    {
        TeamManager.StorageComponent.Import(saveData.TeamManagerSaveData.TeamManagerComponentStorageSaveData);
    }

    public void InitializeForNewGame() 
    {
        TeamManager.StorageComponent.InitializeForNewGame();
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
