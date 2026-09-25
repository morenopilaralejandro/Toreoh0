public class DialogStateMachine 
{
    public DialogState State { get; private set; }

    public DialogStateMachine() 
    {

    }

    public void SetState(DialogState state) 
    {
        State = state;
    }
}
