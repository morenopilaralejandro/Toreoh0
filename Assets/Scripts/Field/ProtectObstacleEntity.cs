using UnityEngine;
using System.Threading.Tasks;

public class ProtectObstacleEntity : MonoBehaviour
{
    public ProtectObstacleComponentAppearanceBattle AppearanceComponentBattle;
    public ProtectObstacle ProtectObstacle;

    public async Task LoadAsync()
    {
        await AppearanceComponentBattle.SetAsync();
    }

    public void Initialize(ProtectObstacleData data)
    {
        ProtectObstacle = ProtectObstacleFactory.Create(data);
    }
}
