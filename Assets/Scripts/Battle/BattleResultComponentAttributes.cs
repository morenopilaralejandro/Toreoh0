using UnityEngine;
using Aremoreno.Enums.Battle;

public class BattleResultComponentAttributes
{
    public BattleType BattleType;
    public BattleFormat BattleFormat;
    public BattleResultContinueType BattleResultContinueType;

    public BattleResultComponentAttributes(BattleResultSaveData saveData)
    {
        BattleType = saveData.BattleType;
        BattleFormat = saveData.BattleFormat;
        BattleResultContinueType = saveData.BattleResultContinueType;
    }
}
