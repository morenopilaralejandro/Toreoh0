using System.Collections.Generic;
using Aremoreno.Enums.Battle;

[System.Serializable]
public class BattleResultSaveData 
{
    public int ProtectObstacleCountStart;
    public int ProtectObstacleCountEnd;

    public bool IsForcedLose;
    public bool IsForcedWin;

    public bool IsNorthWinner;
    public bool IsSouthWinner;
    public BattleSide SideWinner;
    public BattleSide SideLoser;
    public BattleSide SideUser;

    public BattleType BattleType;
    public BattleFormat BattleFormat;
    public BattleResultContinueType BattleResultContinueType;

    public List<ItemReward> ListItemReward;
}
