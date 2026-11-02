using UnityEngine;
using Aremoreno.Enums.Battle;

public class BattleResultComponentProtectObstacle
{
    public int ProtectObstacleCountStart;
    public int ProtectObstacleCountEnd;

    public BattleResultComponentProtectObstacle(BattleResultSaveData saveData)
    {
        ProtectObstacleCountStart = saveData.ProtectObstacleCountStart;
        ProtectObstacleCountEnd = saveData.ProtectObstacleCountEnd;
    }

    public bool IsProtectBonus() => ProtectObstacleCountStart == ProtectObstacleCountEnd && ProtectObstacleCountStart > 0;
}
