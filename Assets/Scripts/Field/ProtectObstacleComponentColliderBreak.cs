using UnityEngine;
using Aremoreno.Enums.Battle;

public class ProtectObstacleComponentColliderBreak : MonoBehaviour
{
    public ProtectObstacleEntity ProtectObstacleEntity;
    [SerializeField] private Collider colliderObstacle;

    public void Break()
    {
        colliderObstacle.enabled = false;
        _ = AudioManager.Instance.Sfx.Play(ProtectObstacleEntity.ProtectObstacle.ProtectObstacleComponentSfx.SfxAddress);
        ProtectObstacleEntity.ProtectObstacle.StateMachineComponent.Set(ProtectObstacleState.Wrecked);
        _ = ProtectObstacleEntity.ProtectObstacleComponentAppearanceBattle.SetAsync();
        // ProtectObstacleEntity.SetActive(false);
        // Change appearience and disable this collider (get collider as SerializeField)
    }
}
