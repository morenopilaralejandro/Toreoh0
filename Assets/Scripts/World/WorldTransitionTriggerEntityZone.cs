using UnityEngine;

public class WorldTransitionTriggerEntityZone : WorldTransitionTriggerEntity
{
    [SerializeField] private string spawnPointId;

    protected override void Transition() 
    {
        base.Transition();
        _ = worldManager.ZoneLoader.TransitionToZone(spawnPointId);
    }
}
