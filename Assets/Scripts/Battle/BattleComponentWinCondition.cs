public class BattleComponentWinCondition
{
    private Battle battle;
    public IWinCondition WinCondition;

    public BattleComponentWinCondition(Battle battle)
    {
        this.battle = battle;

        // TODO decide wich to use using BattleFormat
        WinCondition = new WinConditionLastStanding();

        WinCondition.Initialize(battle);

    }

    // TODO use event hp decreased

    //TODO 
    // capture decreases the hp of the captured entity to 0 
    // perform the same hp calculation
    // account for capture reward

    /*
    public void UpdateInternal()
    {
        if (WinCondition.CheckCondition())
            battle.BattleComponentEnd.End();
    }
    */
}
