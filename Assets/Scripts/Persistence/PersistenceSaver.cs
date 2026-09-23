public class PersistenceSaver 
{
    private PersistenceConfig config;
    private PersistenceWriter writer;

    public PersistenceSaver(PersistenceConfig config, PersistenceWriter writer) 
    {
        this.config = config;
        this.writer = writer;
    }

    public void SaveGame()
    {
        PersistenceEvents.OnGameSaveStarted.Invoke();
        SaveData saveData = CreateSaveData();
        writer.TryWriteSaveData(saveData);
        PersistenceEvents.OnGameSaveEnded.Invoke(saveData);
    }

    private SaveData CreateSaveData() 
    {
        return new SaveData 
        {
            SaveDataHeader = CreateHeader();
            PlayTimeSaveData = PersistenceManager.Instance.PlayTimeTracker.Export();
            //system export
        };
    }

    private SaveDataHeader CreateHeader() 
    {
        return new SaveDataHeader 
        {
            FileSignature = config.FileSignature;
            GameIdetifier = config.GameIdetifier;
            SaveFormatVersion = config.SaveFormatVersion;
            GameVersion = Application.version;
        };
    }
}
