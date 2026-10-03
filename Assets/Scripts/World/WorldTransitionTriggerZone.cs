public class WorldTransitionTriggerZone : WorldTransitionTrigger
{
    [SerializeField] private ZoneData zoneData;
    [SerializeField] private string spawnId;

    protected override void Transition() 
    {
        base.Transition();
        worldManager.ZoneLoader.TransitionToZone(zoneData, spawnId);
    }
}
