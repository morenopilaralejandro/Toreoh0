using System;

public static class BattleEvents
{
    public static event Action<Battle> OnBattleStarted;
    public static void RaiseBattleStarted(Battle battle) 
        => OnBattleStarted?.Invoke(battle);

    public static event Action OnBattleEnded;
    public static void RaiseBattleEnded() 
        => OnBattleEnded?.Invoke();
}
