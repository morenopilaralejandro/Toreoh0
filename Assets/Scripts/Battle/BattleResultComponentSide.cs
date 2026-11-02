using UnityEngine;
using Aremoreno.Enums.Battle;

public class BattleResultComponentSide
{
    public bool IsForcedLose;
    public bool IsForcedWin;

    public BattleSide SideWinner;
    public BattleSide SideUser;

    public BattleResultComponentSide(BattleResultSaveData saveData)
    {
        IsForcedLose = saveData.IsForcedLose;
    }
}
