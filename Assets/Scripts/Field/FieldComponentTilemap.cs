using UnityEngine;
using System.Threading.Tasks;

public class FieldComponentTilemap
{
    private Field field;
    private Transform parentTileMap;
    private readonly AddressableBinding<GameObject> binding = new();

    public FieldComponentTilemap(Field field, Transform parentTileMap)
    {
        this.field = field;
        this.parentTileMap = parentTileMap;
    }

    public void Clear()
    {
        binding.CancelAndRelease();
    }

    public async Task SetAsync() 
    {
        var prefab = await binding.LoadAssetAsync(field.AppearanceComponent.AddressFieldTileMap);
        BattleManager.Instance.InstantiateGameObject(prefab, parentTileMap);
    }
}
