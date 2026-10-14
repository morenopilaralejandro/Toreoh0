public class StoryManagerPersistence
{
    private StoryManager storyManager;

    public StoryManagerPersistence(StoryManager storyManager)
    {
        this.storyManager = storyManager;
    }

    public StoryManagerSaveData Export()
    {
        return new StoryManagerSaveData 
        {
            ChestSystemSaveData = storyManager.ChestTracker.Export()
        };
    }

    public void Import(SaveData saveData) 
    {
        storyManager.ChestTracker.Import(saveData.StoryManagerSaveData.ChestSystemSaveData);
    }

    public void InitializeForNewGame() 
    {
        storyManager.ChestTracker.Clear();
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
