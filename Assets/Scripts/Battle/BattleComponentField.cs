using UnityEngine;
using System.Threading.Tasks;

public class BattleComponentField
{
    private Battle battle;
    public Field Field;

    public BattleComponentField(
        Battle battle, 
        Transform parentTileMap, 
        Transform parentProtectObstacle, 
        Transform parentBarrier) 
    {
        this.battle = battle;
        Field = new Field(
            DatabaseManager.Instance.DatabaseRegistry.FieldData.Get(BattleArgs.FieldId),
            battle.ConfigComponent.BattleConfig,
            parentTileMap,
            parentProtectObstacle,
            parentBarrier
        );
    }

    public async Task LoadAsync()
    {
        await Field.TilemapComponent.SetAsync();
        await Field.ProtectObstacleComponent.LoadAsync();
        await Field.BarrierComponent.LoadAsync();
    }

    public void Dispose() 
    {
        Field.Dispose();
    }
}
