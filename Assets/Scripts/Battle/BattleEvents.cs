using System;
using Aremoreno.Enums.Battle;

public static class BattleEvents
{
    public static event Action<Battle> OnBattleStarted;
    public static void RaiseBattleStarted(Battle battle) 
        => OnBattleStarted?.Invoke(battle);

    public static event Action OnBattleEnded;
    public static void RaiseBattleEnded() 
        => OnBattleEnded?.Invoke();

    public static event Action<BattlePhase, BattlePhase> OnBattlePhaseChanged;
    public static void RaiseBattlePhaseChanged(BattlePhase battlePhaseNew, BattlePhase battlePhaseOld) 
        => OnBattlePhaseChanged?.Invoke(battlePhaseNew, battlePhaseOld);

    public static event Action<bool> OnIsEnemyAiEnabledChanged;
    public static void RaiseIsEnemyAiEnabledChanged(bool isEnable)
        => OnIsEnemyAiEnabledChanged?.Invoke(isEnable);
}
