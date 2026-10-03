public class WorldTransitionTriggerComponentStateMachine
{
    public WorldTransitionTriggerState State { get; private set; }
    public void SetState(WorldTransitionTriggerState state) => State = state;
}
