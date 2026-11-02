using UnityEngine;
using Aremoreno.Enums.Battle;

public class BattleComponentAttributes
{
    public BattleType BattleType;
    public BattleFormat BattleFormat;
    public BattleResultContinueType BattleResultContinueType;

    public BattleComponentAttributes()
    {
        BattleType = BattleArgs.BattleType;
        BattleFormat = BattleArgs.BattleFormat;
        BattleResultContinueType = BattleArgs.BattleResultContinueType;
    }
}
