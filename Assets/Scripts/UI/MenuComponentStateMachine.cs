using System;
using System.Collections.Generic;

public class MenuComponentStateMachine<TState> where TState : System.Enum
{
    private readonly Dictionary<TState, Action> dictEnter = new ();
    private readonly Dictionary<TState, Action> dictExit = new ();
    public event Action<TState, TState> OnStateChanged;
    public TState State;

    public MenuComponentStateMachine(TState state) 
    {
        State = state;
    }

    public MenuComponentStateMachine<TState> OnEnter(TState state, Action action)
    {
        dictEnter[state] = action;
        return this;
    }

    public MenuComponentStateMachine<TState> OnExit(TState state, Action action)
    {
        dictExit[state] = action;
        return this;
    }

    public bool Is(TState state) => EqualityComparer<TState>.Default.Equals(State, state);
    public void Set(TState newState) 
    {
        if (Is(newState)) return;
        var oldState = State;
        if (dictExit.TryGetValue(oldState, out var actionExit)) actionExit(); 
        State = newState;
        if (dictEnter.TryGetValue(newState, out var actionEnter)) actionEnter(); 
        OnStateChanged?.Invoke(newState, oldState);
    }

    /*
        stateMachine = new MenuComponentStateMachine<MenuStateBasic>(MenuStateBasic.Idle)
            .OnEnter(MenuStateBasic.WaitingForConfirm, () =>
            {
                UIEvents.RaiseDialogConfirOpenRequested(null, null)
            })
            .OnExit(MenuStateBasic.WaitingForConfirm, () =>
            {
                OnClicked(lastSelectedElement); this doent handle the is auto save check
            })
            .OnExit(MenuStateBasic.WaitingForSelection, () =>
            {
                SetState as confirm
            });
    */
}
