using UnityEngine;
using Aremoreno.Enums.Battle;

public static class BattleArgs
{
    // battle
    public static BattleType BattleType;
    public static BattleFormat BattleFormat;
    public static BattleResultContinueType BattleResultContinueType;

    // field
    public static string FieldId;

    // team
    public static string TeamSouthId;
    public static TeamSaveData TeamSouthSaveData;

    public static string TeamNorthId;
    public static TeamSaveData TeamNorthSaveData;

    // results
    public static BattleResultSaveData BattleResultSaveData;

    // setter
    public static void SetForTest() 
    {
        Clear();
        BattleType = BattleType.Full;
        BattleFormat = BattleFormat.Single;
        BattleResultContinueType = BattleResultContinueType.Test;

        FieldId = "field-00000-test-full";

        TeamSouthId = "team-00000-test_a";
        TeamNorthId = "team-00000-test_b";
    }

    public static void SetForResults(Battle battle) 
    {
        BattleResultSaveData = battle.BattleComponentPersistence.ExportAsBattleResultSaveData();
    }

    // clear
    public static void Clear() 
    {

    }
}
