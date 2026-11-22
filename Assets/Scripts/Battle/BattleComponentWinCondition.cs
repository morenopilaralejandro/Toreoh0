public class BattleComponentWinCondition
{
    private Battle battle;
    public IWinCondition WinCondition;
    public CharacterEntityBattle entityLastDamaged;

    public BattleComponentWinCondition(Battle battle)
    {
        this.battle = battle;

        // TODO decide wich to use using BattleFormat
        // new win con last standing user
        WinCondition = new WinConditionLastStanding();

        WinCondition.Initialize(battle);
    }

    public void Subscribe()
    {               
        UIEvents.OnCharacterHpDecreased += OnCharacterHpDecreased;
    }

    public void Unsubscribe()
    {
        UIEvents.OnCharacterHpDecreased -= OnCharacterHpDecreased;
    }

    private void OnCharacterHpDecreased(CharacterEntityBattle entity) 
    {
        entityLastDamaged = entity;
        if (WinCondition.CheckCondition())
            battle.BattleComponentEnd.End();
    }
}



    // TODO use event hp decreased
    // keep track of last damaged character


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
