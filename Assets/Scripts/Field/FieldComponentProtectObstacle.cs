using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FieldComponentProtectObstacle
{
    private Field field;
    private string protectObstacleId;
    private Transform parentProtectObstacle;
    private readonly AddressableBinding<GameObject> binding = new();
    public List<ProtectObstacle> ListProtectObstacle = new ();

    public FieldComponentProtectObstacle(FieldData data, Field field, Transform parentProtectObstacle)
    {
        this.field = field;
        this.protectObstacleId = data.ProtectObstacleId;
        this.parentProtectObstacle = parentProtectObstacle;
    }

    public void Clear()
    {
        ListProtectObstacle.Clear();
        binding.CancelAndRelease();
    }

    public async Task LoadAsync()
    {
        var prefab = await binding.LoadAssetAsync("prefab-ProtectObstacleEntity");
        var listFormationCoord = field.FormationComponent.Formation.CoordsComponent.ListFormationCoord;
        var data = DatabaseManager.Instance.DatabaseRegistry.ProtectObstacleData.Get(protectObstacleId);

        for (int i = 1; i < listFormationCoord.Count; i++) 
        {
            var go = BattleManager.Instance.InstantiateGameObject(
                prefab,
                listFormationCoord[i].PositionComponent.FormationCoordPosition,
                Quaternion.identity,
                parentProtectObstacle) as GameObject;
            var entity = go.GetComponent<ProtectObstacleEntity>();
            ListProtectObstacle.Add(entity.ProtectObstacle);
            entity.Initialize(data);
            await entity.LoadAsync();
        }
    }
}
