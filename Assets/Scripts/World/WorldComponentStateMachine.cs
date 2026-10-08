using Aremoreno.Enums.World;

public class WorldComponentStateMachine 
{
    public WorldState State { get; private set; }

    public void SetState(WorldState state)
    {
        WorldEvents.RaiseWorldStateChanged(state, State);
        State = state;
    }
}
