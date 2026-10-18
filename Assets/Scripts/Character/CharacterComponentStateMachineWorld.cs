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
        UIEvents.OnMenuOpened += OnMenuOpened;
        UIEvents.OnMenuClosedAll += OnMenuClosedAll;
    }

    public void Unsubscribe()
    {
        WorldEvents.OnWorldStateChanged -= OnWorldStateChanged;
        UIEvents.OnMenuOpened -= OnMenuOpened;
        UIEvents.OnMenuClosedAll -= OnMenuClosedAll;
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

    private void OnMenuOpened(Menu menu)
    {
        SetState(WorldStateCharacter.InMenu);
    }

    private void OnMenuClosedAll()
    {
        SetState(WorldStateCharacter.Freeroam);
    }
}
