using UnityEngine;
using Aremoreno.Enums.Animation;

public class SpawnPoint : MonoBehaviour
{
    public string SpawnPointId;
    public CharacterDirection FacingDirection;

    public Vector3 SpawnPosition => transform.position;

    private void OnDrawGizmos() 
    {
        GizmosUtils.DrawSphere(
            WorldConstants.GizmosColorSpawnPoint, 
            transform.position, 
            0.3f);
        GizmosUtils.DrawRay(
            WorldConstants.GizmosColorSpawnPointDirection, 
            transform.position, 
            (Vector3)CharacterDirectionUtils.EnumToVector2(FacingDirection) * 0.5f);
    }
}
