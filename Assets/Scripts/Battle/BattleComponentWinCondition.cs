using Aremoreno.Enums.Battle;

public class BattleComponentWinCondition
{
    private Battle battle;
    public IWinCondition WinCondition;
    public CharacterEntityBattle EntityLastDamaged;

    public BattleComponentWinCondition(Battle battle)
    {
        this.battle = battle;

        WinCondition = new WinConditionLastStandingUser();

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
        if (battle.BattleComponentPause.IsPausedBattle) return;
        EntityLastDamaged = entity;
        if (WinCondition.CheckCondition())
            battle.BattleComponentEnd.EndByCondition();
    }

    public BattleSide GetBattleSideLoser() 
    {
        if (EntityLastDamaged == null)
            return BattleSide.South;
        else
            return EntityLastDamaged.Character.CharacterComponentSide.BattleSide;
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
