using UnityEngine;
using Aremoreno.Enums.Battle;

public static class BattleArgs
{
    public static BattleType BattleType;
    public static BattleFormat BattleFormat;
    public static string FieldId;

    public static void SetForTest() 
    {
        BattleType = BattleType.Full;
        BattleFormat = BattleFormat.Single;
        FieldId = "field-00000-test-full";
    }
}
