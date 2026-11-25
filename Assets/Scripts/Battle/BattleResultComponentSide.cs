using UnityEngine;
using Aremoreno.Enums.Battle;

public class BattleResultComponentSide
{
    private CharacterComponentSide componentSide;

    public bool IsUserWin;
    public bool IsForcedLose;
    public bool IsForcedWin;
    public BattleSide BattleSideLoser;
    public BattleSide BattleSideUser;

    public BattleResultComponentSide(BattleResultSaveData saveData)
    {
        IsForcedLose = saveData.IsForcedLose;
        IsForcedWin = saveData.IsForcedLose;
        BattleSideLoser = saveData.BattleSideLoser;
        BattleSideUser = saveData.BattleSideUser;
        componentSide = new CharacterComponentSide(null);

        if (IsForcedLose) 
            IsUserWin = false;
        else if (IsForcedWin)
            IsUserWin = true;
        else
            IsUserWin = !componentSide.IsSameTeam(BattleSideLoser, BattleSideUser);
    }
}
