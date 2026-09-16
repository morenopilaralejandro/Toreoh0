using UnityEngine.InputSystem;
using System;
using System.Collections.Generic;

public abstract class InputActionMap<T> : IInputActionMap where T : Enum
{
    protected InputActionsGame inputActions;
    protected InputStateTracker<T> tracker;
    
    public InputStateTracker<T> Tracker => tracker;

    public virtual void Initialize(InputActionsGame inputActions, InputStateTracker<T> tracker) 
    {
        this.inputActions = inputActions;
        this.tracker = tracker;
        BindAll();
    }

    public virtual void Reset() => tracker.InvalidateAllBuffers();

    protected abstract void BindAll();

    protected void Bind(InputAction inputAction, T input) 
    {
        inputAction.started += _ => OnActionStarted(input);
        inputAction.canceled += _ => OnActionCanceled(input);
    }

    protected virtual void OnActionStarted(T input) => tracker.RecordButtonDown(input);
    protected virtual void OnActionCanceled(T input) => tracker.RecordButtonUp(input);

    public abstract void Enable();
    public abstract void Disable();
}
