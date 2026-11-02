using UnityEngine;

public class BattleResult
{
    public BattleResultComponentAttributes BattleResultComponentAttributes;
    public BattleResultComponentSide BattleResultComponentSide;
    public BattleResultComponentProtectObstacle BattleResultComponentProtectObstacle;
    public BattleResultComponentItem BattleResultComponentItem;
    // xp

    public BattleResult(BattleResultSaveData saveData)
    {
        BattleResultComponentAttributes = new BattleResultComponentAttributes(saveData);
        BattleResultComponentSide = new BattleResultComponentSide(saveData);
        BattleResultComponentProtectObstacle = new BattleResultComponentProtectObstacle(saveData);
        BattleResultComponentItem = new BattleResultComponentItem(saveData);
    }
}
