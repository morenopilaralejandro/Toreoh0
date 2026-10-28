using UnityEngine;
using System.Threading.Tasks;

public class BattleComponentField
{
    private Battle battle;
    public Field Field;

    public BattleComponentField(Battle battle, Transform parentTileMap, Transform parentProtectObstacle) 
    {
        this.battle = battle;
        Field = new Field(
            DatabaseManager.Instance.DatabaseRegistry.FieldData.Get(BattleArgs.FieldId),
            battle.ConfigComponent.BattleConfig,
            parentTileMap,
            parentProtectObstacle
        );
    }

    public async Task LoadAsync() 
    {
        await Field.TilemapComponent.SetAsync();
        await Field.ProtectObstacleComponent.LoadAsync();
    }

    public void Dispose() 
    {
        Field.Dispose();
    }
}
