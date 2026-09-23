public class PersistenceLoader
{
    private PersistenceConfig config;
    private PersistenceWriter writer;

    public PersistenceLoader(PersistenceConfig config, PersistenceWriter writer) 
    {
        this.config = config;
        this.writer = writer;
    }

    public void LoadGame()
    {
        PersistenceEvents.OnGameLoadStarted.Invoke();
        SaveData saveData = null;
        writer.TryGetLastSaveData(out saveData);
        PersistenceEvents.OnGameLoadEnded.Invoke(saveData);
    }
}
