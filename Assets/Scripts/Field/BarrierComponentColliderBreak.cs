using UnityEngine;

public class BarrierComponentColliderBreak : MonoBehaviour
{
    public BarrierEntity BarrierEntity;

    public void Break() 
    {
        _ = AudioManager.Instance.Sfx.Play(BarrierEntity.Barrier.BarrierComponentSfx.SfxAddress);
        BarrierEntity.gameObject.SetActive(false);
    }
}
