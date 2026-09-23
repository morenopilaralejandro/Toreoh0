public class PlayTimeTracker 
{
    public long TimestampSave { get; private set; }
    public long TimestampCreation { get; private set; }
    public long TimestampSessionStart { get; private set; }
    public long PlayTimeSeconds { get; private set; }

    public void StartSession()
    {
        TimestampSessionStart = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }

    public long GetCurrentPlayTimeSeconds()
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        long sessionSeconds = now - TimestampSessionStart;
        return playTimeSeconds + sessionSeconds;
    }

    public PlayTimeSaveData Export() 
    {
        return new PlayTimeSaveData 
        {
            TimestampSave = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            TimestampCreation = TimestampCreation;
            PlayTimeSeconds = GetCurrentPlayTimeSeconds();
        };
    }

    public void Import(PlayTimeSaveData saveData) 
    {
        TimestampSave = saveData.TimestampSave;
        TimestampCreation = saveData.TimestampCreation;
        PlayTimeSeconds = saveData.PlayTimeSeconds;
    }

    //event
    public void Subscribe() 
    {
        PersistenceEvents.OnGameSaveEnded += OnGameSaveEnded;
        PersistenceEvents.OnGameLoadEnded += OnGameLoadEnded;
        PersistenceEvents.OnNewGameStarted += OnNewGameStarted;
    }

    public void Unsubscribe() 
    {
        PersistenceEvents.OnGameSaveEnded -= OnGameSaveEnded;
        PersistenceEvents.OnGameLoadEnded -= OnGameLoadEnded;
        PersistenceEvents.OnNewGameStarted -= OnNewGameStarted;
    }

    private void OnGameSaveEnded(SaveData saveData) 
    {
        StartSession();
    }

    private void OnGameLoadEnded(SaveData saveData) 
    {
        Import();
        StartSession();
    }

    private void OnNewGameStarted()
    {
        TimestampCreation = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        StartSession();
    }
}
