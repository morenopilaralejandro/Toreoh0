using UnityEngine;

public class ProtectObstacleEntity : MonoBehaviour
{
    public ProtectObstacle ProtectObstacle;

    public ProtectObstacleEntity(ProtectObstacleData data)
    {
        ProtectObstacle = ProtectObstacleFactory.Create(data);
    }
}
