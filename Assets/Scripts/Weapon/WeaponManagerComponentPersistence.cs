public class WeaponManagerComponentPersistence
{
    private WeaponManager WeaponManager;

    public WeaponManagerComponentPersistence(WeaponManager WeaponManager)
    {
        this.WeaponManager = WeaponManager;
    }

    public WeaponManagerSaveData Export()
    {
        return new WeaponManagerSaveData 
        {
            WeaponManagerComponentStorageSaveData = WeaponManager.WeaponManagerComponentStorage.Export(),
        };
    }

    public void Import(SaveData saveData)
    {
        WeaponManager.WeaponManagerComponentStorage.Import(saveData.WeaponManagerSaveData.WeaponManagerComponentStorageSaveData);
    }

    public void InitializeForNewGame() 
    {
        WeaponManager.WeaponManagerComponentStorage.InitializeForNewGame();
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
