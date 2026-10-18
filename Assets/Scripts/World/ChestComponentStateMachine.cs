using Aremoreno.Enums.World;

public class ChestComponentStateMachine 
{
    public ChestState State { get; private set; }
    public void SetState(ChestState state) => State = state;
}
