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
            ProtectObstacleCountStart = battle.BattleComponentField.Field.FieldComponentFormation.ProtectObstacleCountStart,
            ProtectObstacleCountEnd = battle.BattleComponentField.Field.FieldComponentProtectObstacle.GetCountAllright(),

            IsForcedLose = battle.BattleComponentEnd.IsForcedLose,
            IsForcedWin = battle.BattleComponentEnd.IsForcedWin,
            BattleSideLoser = battle.BattleComponentWinCondition.GetBattleSideLoser(),
            BattleSideUser = battle.BattleComponentTeam.BattleSideUser,

            BattleType = BattleArgs.BattleType,
            BattleFormat = BattleArgs.BattleFormat,
            BattleResultContinueType = BattleArgs.BattleResultContinueType
        };
    }
}
