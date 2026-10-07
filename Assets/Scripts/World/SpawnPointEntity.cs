using UnityEngine;
using Aremoreno.Enums.Animation;

public class SpawnPointEntity : MonoBehaviour
{
    public string SpawnPointId;
    public CharacterDirection FacingDirection;
    public Vector3 SpawnPosition => transform.position;
    
    public SpawnPoint GetSpawnPoint()
    {
        return new SpawnPoint
        {
            SpawnPointId = SpawnPointId,
            FacingDirection = FacingDirection,
            SpawnPosition = SpawnPosition
        };
    }

    private void OnDrawGizmos() 
    {
        GizmosUtils.DrawSphere(
            WorldConstants.GizmosColorSpawnPoint, 
            transform.position, 
            0.3f,
            false);
        GizmosUtils.DrawRay(
            WorldConstants.GizmosColorSpawnPointDirection, 
            transform.position, 
            (Vector3)CharacterDirectionUtils.EnumToVector2(FacingDirection) * 0.5f);
    }
}
