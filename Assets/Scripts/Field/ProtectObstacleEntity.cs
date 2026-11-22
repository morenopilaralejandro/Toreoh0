using UnityEngine;
using System.Threading.Tasks;

public class ProtectObstacleEntity : MonoBehaviour
{
    public ProtectObstacleComponentAppearanceBattle ProtectObstacleComponentAppearanceBattle;
    public ProtectObstacle ProtectObstacle;

    public void Initialize(ProtectObstacleData data)
    {
        ProtectObstacle = ProtectObstacleFactory.Create(data);
        ProtectObstacleComponentAppearanceBattle.Initialize(this);
    }

    public async Task LoadAsync()
    {
        await ProtectObstacleComponentAppearanceBattle.SetAsync();
    }

    public void OnDestroy()
    {
        ProtectObstacleComponentAppearanceBattle.Clear();
    }
}
