public class BattleComponentPersistence
{
    private Battle battle;

    public BattleComponentPersistence(Battle battle)
    {
        this.battle = battle;
    }

    public BattleResultSaveData ExportAsBattleResultSaveData()
    {
        return new BattleResultSaveData 
        {
            BattleResultContinueType = battle.BattleComponentAttributes.BattleResultContinueType
        };
    }
}
