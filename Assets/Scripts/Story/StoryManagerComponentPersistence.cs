public class StoryManagerComponentPersistence
{
    private StoryManager storyManager;

    public StoryManagerComponentPersistence(StoryManager storyManager)
    {
        this.storyManager = storyManager;
    }

    public StoryManagerSaveData Export()
    {
        return new StoryManagerSaveData 
        {
            ChestSystemSaveData = storyManager.ChestTracker.Export(),
            StoryFlagsSystemSaveData = storyManager.Flags.Export()
        };
    }

    public void Import(SaveData saveData) 
    {
        storyManager.ChestTracker.Import(saveData.StoryManagerSaveData.ChestSystemSaveData);
        storyManager.Flags.Import(saveData.StoryManagerSaveData.StoryFlagsSystemSaveData);
    }

    public void InitializeForNewGame() 
    {
        storyManager.ChestTracker.Clear();
        storyManager.Flags.InitializeForNewGame();
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
