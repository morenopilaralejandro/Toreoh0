using System;

public static class PersistenceEvents
{
    public static event Action OnGameSaveStarted;
    public static void RaiseGameSaveStarted() 
        => OnGameSaveStarted.Invoke();

    public static event Action<SaveData> OnGameSaveEnded;
    public static void RaiseGameSaveEnded(SaveData saveData) 
        => OnGameSaveEnded.Invoke(saveData);

    public static event Action OnGameLoadStarted;
    public static void RaiseGameLoadStarted() 
        => OnGameLoadStarted.Invoke();

    public static event Action<SaveData> OnGameLoadEnded;
    public static void RaiseGameLoadEnded(SaveData saveData)
        => OnGameLoadEnded.Invoke(saveData);

    public static event Action OnNewGameStarted;
    public static void RaiseNewGameStarted()
        => OnNewGameStarted.Invoke();
}
