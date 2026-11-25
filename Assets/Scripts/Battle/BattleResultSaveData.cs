using System.Collections.Generic;
using Aremoreno.Enums.Battle;

[System.Serializable]
public class BattleResultSaveData 
{
    public int ProtectObstacleCountStart;
    public int ProtectObstacleCountEnd;

    public bool IsForcedLose;
    public bool IsForcedWin;

    public BattleSide BattleSideLoser;
    public BattleSide BattleSideUser;

    public BattleType BattleType;
    public BattleFormat BattleFormat;
    public BattleResultContinueType BattleResultContinueType;

    public List<ItemReward> ListItemReward;
}
