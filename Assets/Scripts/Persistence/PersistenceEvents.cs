using System;

public static class PersistenceEvents
{
    public static event Action OnGameSaveStarted;
    public static event Action<SaveData> OnGameSaveEnded;
    public static event Action OnGameLoadStarted;
    public static event Action<SaveData> OnGameLoadEnded;
    public static event Action OnNewGameStarted;
}
