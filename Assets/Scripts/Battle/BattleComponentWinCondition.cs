public class BattleComponentWinCondition
{
    private Battle battle;
    public IWinCondition WinCondition;

    public BattleComponentWinCondition(Battle Battle)
    {
        this.battle = Battle;

        // TODO decide wich to use using BattleFormat
        WinCondition = new WinConditionLastStanding();


    }

    public void UpdateInternal()
    {
        if (WinCondition.CheckCondition())
            battle.BattleComponentEnd.End();
    }
}
