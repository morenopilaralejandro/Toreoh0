using Aremoreno.Enums.Battle;

public class BattleComponentEnd
{
    private Battle battle;
    private bool isEndPending;
    public bool IsForcedWin;
    public bool IsForcedLose;

    public BattleComponentEnd(Battle battle)
    {
        this.battle = battle;
    }

    public void End() 
    {
        if (!IsValid()) return;
        BattleArgs.SetForResults(battle);
        SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-BattleResult");
    }

    public void EndByForfeit()
    {
        if (!IsValid()) return;
        BattleArgs.SetForResults(battle);
        SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-BattleResult");
    }

    private bool IsValid() 
    {
        if (isEndPending) 
        {
            return false;
        } else 
        {
            isEndPending = true;
            return true;
        }
    }
}
