using System;

public class CharacterComponentStateMachine<T> where T : System.Enum
{
    public T State { get; private set; }

    public event Action<T> OnStateChanged;
    public void SetState(T state) 
    {
        State = state;
        OnStateChanged?.Invoke(State);
    }
    
    public bool Is(T state) => State.Equals(state);
}
