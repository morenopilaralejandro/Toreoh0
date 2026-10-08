using Aremoreno.Enums.World;

public class CharacterComponentStateMachineWorld
{
    public WorldStateCharacter State = WorldStateCharacter.Processing;

    public void SetState(WorldStateCharacter state)
    {
        State = state;
    }

    public void Subscribe()
    {
        WorldEvents.OnWorldStateChanged += OnWorldStateChanged;
    }

    public void Unsubscribe()
    {
        WorldEvents.OnWorldStateChanged -= OnWorldStateChanged;
    }

    private void OnWorldStateChanged(WorldState stateNew, WorldState stateOld)
    {
        switch(stateNew) 
        {
            case WorldState.Processing:
                SetState(WorldStateCharacter.Processing);
                break;
        }

        switch(stateOld) 
        {
            case WorldState.Processing:
                SetState(WorldStateCharacter.Freeroam);
                break;
        }
    }
}
