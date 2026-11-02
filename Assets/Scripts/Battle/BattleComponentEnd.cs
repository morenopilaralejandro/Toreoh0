using Aremoreno.Enums.Battle;

public class BattleComponentEnd
{
    private Battle battle;

    public BattleComponentEnd(Battle battle)
    {
        this.battle = battle;
    }

    public void End() 
    {
        SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-BattleResult");
    }

    public void EndByForfeit()
    {
        BattleArgs.SetForResults(battle);
        SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-BattleResult");
    }
}
