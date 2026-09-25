public class DialogManagerPersistence
{
    private DialogManager dialogManager;

    public DialogManagerPersistence(DialogManager dialogManager) 
    {
        this.dialogManager = dialogManager;
    }

    public DialogManagerSaveData Export() 
    {
        return new DialogManagerSaveData 
        {
            InkStorySaveDataList = dialogManager.InkStoryComponent.Export(),
            ViewedDialogsList = dialogManager.ViewedTracker.Export()
        };
    }

    public void Import(DialogManagerSaveData saveData) 
    {
        dialogManager.InkStoryComponent.Import(saveData.DialogManagerSaveData);
        dialogManager.ViewedTracker.Import(saveData.DialogManagerSaveData);
    }

    public void InitializeForNewGame() 
    {
        dialogManager.InkStoryComponent.Clear();
        dialogManager.ViewedTracker.Clear();
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

    private void OnGameLoadEnded(SaveData saveData) => Import();
    private void OnNewGameStarted() => InitializeForNewGame();
}
