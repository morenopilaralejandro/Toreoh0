using UnityEngine;
using Aremoreno.Enums.Battle;

public static class BattleArgs
{
    public static BattleType BattleType;
    public static BattleFormat BattleFormat;
    public static BattleResultContinueType BattleResultContinueType;

    public static string FieldId;
    public static string TeamNorthId;
    public static TeamSaveData TeamNorthSaveData;

    public static BattleResultSaveData BattleResultSaveData;

    public static void SetForTest() 
    {
        Clear();
        BattleType = BattleType.Full;
        BattleFormat = BattleFormat.Single;
        BattleResultContinueType = BattleResultContinueType.Test;
        FieldId = "field-00000-test-full";
    }

    public static void SetForResults(Battle battle) 
    {
        BattleResultSaveData = battle.BattleComponentPersistence.ExportAsBattleResultSaveData();
    }

    public static void Clear() 
    {

    }
}
