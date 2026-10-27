using System;
using Aremoreno.Enums.Battle;

public class ProtectObstacleComponentStateMachine
{
    public ProtectObstacleState State;
    public Action<ProtectObstacleState> OnStateChanged;

    public ProtectObstacleComponentStateMachine()
    {

    }

    public void Set(ProtectObstacleState state)
    {
        State = state;
        OnStateChanged?.Invoke(state);
    }

    public bool Is(ProtectObstacleState state) => state == State;
}
