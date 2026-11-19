using UnityEngine;
using Aremoreno.Enums.Battle;

public class ProtectObstacleComponentColliderBreak : MonoBehaviour
{
    public ProtectObstacleEntity ProtectObstacleEntity;

    public void Break() 
    {
        _ = AudioManager.Instance.Sfx.Play(ProtectObstacleEntity.ProtectObstacle.ProtectObstacleComponentSfx.SfxAddress);
        ProtectObstacleEntity.ProtectObstacle.StateMachineComponent.Set(ProtectObstacleState.Wrecked);
        // ProtectObstacleEntity.SetActive(false);
        // Change appearience and disable this collider (get collider as SerializeField)
    }
}
