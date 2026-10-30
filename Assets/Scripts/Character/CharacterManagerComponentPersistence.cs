public class CharacterManagerComponentPersistence
{
    private CharacterManager CharacterManager;

    public CharacterManagerComponentPersistence(CharacterManager CharacterManager)
    {
        this.CharacterManager = CharacterManager;
    }

    public CharacterManagerSaveData Export()
    {
        return new CharacterManagerSaveData 
        {
            CharacterManagerComponentStorageSaveData = CharacterManager.CharacterManagerComponentStorage.Export(),
        };
    }

    public void Import(SaveData saveData) 
    {
        CharacterManager.CharacterManagerComponentStorage.Import(saveData.CharacterManagerSaveData.CharacterManagerComponentStorageSaveData);
    }

    public void InitializeForNewGame() 
    {
        CharacterManager.CharacterManagerComponentStorage.InitializeForNewGame();
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
