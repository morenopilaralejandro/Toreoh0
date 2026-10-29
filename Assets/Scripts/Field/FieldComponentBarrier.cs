using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FieldComponentBarrier
{
    private Field field;
    private Transform parentBarrier;
    private List<AddressableBinding<GameObject>> listBinding = new ();
    public List<Barrier> ListBarrier = new ();

    public FieldComponentBarrier(Field field, Transform parentBarrier)
    {
        this.field = field;
        this.parentBarrier = parentBarrier;
    }

    public void Clear()
    {
        ListBarrier.Clear();
        foreach (var binding in listBinding)
            binding.CancelAndRelease();
        listBinding.Clear();
    }

    public async Task LoadAsync()
    {
        var listBarrierId = field.FormationBarrierComponent.ListBarrierId;
        var listCoord = field.FormationBarrierComponent.Formation.CoordsComponent.ListFormationCoord;

        for (int i = 0; i < listBarrierId.Count; i++)
        {
            var data = DatabaseManager.Instance.DatabaseRegistry.BarrierData.Get(listBarrierId[i]);
            AddressableBinding<GameObject> binding = new();
            string address = AddressableBuilder.GetBarrierPrefabAddress(data.BarrierType.ToString());
            var prefab = await binding.LoadAssetAsync(address);
            listBinding.Add(binding);

            var go = BattleManager.Instance.InstantiateGameObject(
                prefab,
                listCoord[i].PositionComponent.FormationCoordPosition,
                listCoord[i].RotationComponent.FormationCoordRotation,
                parentBarrier) as GameObject;
            var entity = go.GetComponent<BarrierEntity>();
            ListBarrier.Add(entity.Barrier);
            entity.Initialize(data);
            await entity.LoadAsync();
        }
    }
}
