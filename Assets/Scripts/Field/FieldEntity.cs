using UnityEngine;
using System.Threading.Tasks;

public class FieldEntity : MonoBehaviour, IAsyncSceneLoader
{
    public FieldComponentTilemap TilemapComponent;
    public Field Field;

    public async Task LoadAsync()
    {
        Initialize(DatabaseManager.Instance.DatabaseRegistry.SceneGroupData.Get(BattleArgs.FieldId);)
        await AppearanceComponentBattle.SetAsync();

        
    }

    public void Initialize(FieldData data)
    {
        Field = FieldFactory.Create(data);
    }
}
