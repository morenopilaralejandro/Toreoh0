using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using System;
using Aremoreno.Enums.Input;

public class InputActionMapTouch : InputActionMap<InputTouch>
{
    // fields
    public Vector2 PointerPosition { get; private set; }
    public Vector2 PointerDelta { get; private set; }

    // events
    public event Action<InputSwipeDirection> OnSwipePerformed;
    public event Action<Vector2> OnDragStared;
    public event Action<Vector2> OnDragPerformed;
    public event Action<Vector2> OnDragCanceled;

    public event Action OnSingleTapPerformed;
    public event Action OnDoubleTapPerformed;

    // passthrough only has performed
    // combine Press with position or delta to have start, performed and cancel 

    protected override void BindAll() 
    {
        inputActions.ActionsTouch.PointerPosition.performed += OnPointerPositionPeformed;
        //inputActions.ActionsTouch.PointerPosition.canceled += OnPointerPositionCanceled;

        inputActions.ActionsTouch.PointerPress.started += OnPointerDeltaStarted;
        inputActions.ActionsTouch.PointerDelta.performed += OnPointerDeltaPerformed;
        inputActions.ActionsTouch.PointerPress.canceled += OnPointerDeltaCanceled;

        inputActions.ActionsTouch.Tap.performed += OnTapPerformed;

        Bind(inputActions.ActionsTouch.Tap, InputTouch.Tap);
    }

    public override void Enable() => inputActions.ActionsTouch.Enable();
    public override void Disable() => inputActions.ActionsTouch.Disable();

    private void OnPointerPositionPeformed(InputAction.CallbackContext context) => PointerPosition = context.ReadValue<Vector2>();
    //private void OnPointerPositionCanceled(InputAction.CallbackContext context) => PointerPosition = Vector2.zero;

    public override void Reset()
    {
        base.Reset();
        PointerPosition = Vector2.zero;
        PointerDelta = Vector2.zero;
    }

    private void OnPointerDeltaStarted(InputAction.CallbackContext context) 
    {
        OnDragStared?.Invoke(PointerPosition);
    }

    private void OnPointerDeltaPerformed(InputAction.CallbackContext context) 
    {
        PointerDelta = context.ReadValue<Vector2>();
        OnDragPerformed?.Invoke(PointerDelta);
    }

    private void OnPointerDeltaCanceled(InputAction.CallbackContext context) 
    {
        OnDragCanceled?.Invoke(PointerPosition);

        // detect swipe
        if (Mathf.Abs(PointerDelta.magnitude) < config.SwipeMagnitudeMin) return;
        if (Mathf.Abs(PointerDelta.x) > Mathf.Abs(PointerDelta.y))
        {
            // horizontal
            if (PointerDelta.x > 0)
                OnSwipePerformed?.Invoke(InputSwipeDirection.Right);
            else if (PointerDelta.x < 0)
                OnSwipePerformed?.Invoke(InputSwipeDirection.Left);
        }
        else 
        {
            // vertical
            if (PointerDelta.y > 0)
                OnSwipePerformed?.Invoke(InputSwipeDirection.Up);
            else if (PointerDelta.y < 0)
                OnSwipePerformed?.Invoke(InputSwipeDirection.Down);
        }
    }

    private void OnTapPerformed(InputAction.CallbackContext context) 
    {
        if (context.interaction is TapInteraction)
            OnSingleTapPerformed?.Invoke();
        else if (context.interaction is MultiTapInteraction interaction && interaction.tapCount == 2)
            OnDoubleTapPerformed?.Invoke();
    }
}
