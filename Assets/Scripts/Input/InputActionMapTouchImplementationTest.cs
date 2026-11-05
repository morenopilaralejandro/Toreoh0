using UnityEngine;
using UnityEngine.InputSystem;
using Aremoreno.Enums.Input;

public class InputActionMapTouchImplementationTest : MonoBehaviour
{
    private void OnEnable()
    {
        InputManager.Instance.MapTouch.Tracker.OnButtonDown += OnButtonDown;
        InputManager.Instance.MapTouch.Tracker.OnButtonUp += OnButtonUp;

        InputManager.Instance.MapTouch.OnSingleTapPerformed += OnSingleTapPerformed;
        InputManager.Instance.MapTouch.OnDoubleTapPerformed += OnDoubleTapPerformed;

        InputManager.Instance.MapTouch.OnSwipePerformed += OnSwipePerformed;

        InputManager.Instance.MapTouch.OnDragStared += OnDragStared;
        InputManager.Instance.MapTouch.OnDragPerformed += OnDragPerformed;
        InputManager.Instance.MapTouch.OnDragCanceled += OnDragCanceled;
    }

    private void OnDisable()
    {
        InputManager.Instance.MapTouch.Tracker.OnButtonDown -= OnButtonDown;
        InputManager.Instance.MapTouch.Tracker.OnButtonUp -= OnButtonUp;

        InputManager.Instance.MapTouch.OnSingleTapPerformed -= OnSingleTapPerformed;
        InputManager.Instance.MapTouch.OnDoubleTapPerformed -= OnDoubleTapPerformed;

        InputManager.Instance.MapTouch.OnSwipePerformed -= OnSwipePerformed;

        InputManager.Instance.MapTouch.OnDragStared -= OnDragStared;
        InputManager.Instance.MapTouch.OnDragPerformed -= OnDragPerformed;
        InputManager.Instance.MapTouch.OnDragCanceled -= OnDragCanceled;
    }

    // button
    private void OnButtonDown(InputTouch input) 
    {
        switch(input)
        {
            case InputTouch.Tap:
                CustomLog.Warning($"Tap Down");
                break;
        }
    }

    private void OnButtonUp(InputTouch input) 
    {
        switch(input)
        {
            case InputTouch.Tap:
                CustomLog.Warning($"Tap Up");
                break;
        }
    }

    // tap
    private void OnSingleTapPerformed()
    {
        CustomLog.Error($"OnSingleTapPerformed");
    }

    private void OnDoubleTapPerformed()
    {
        CustomLog.Error($"OnDoubleTapPerformed");
    }

    // swipe
    private void OnSwipePerformed(InputSwipeDirection direction) 
    {
        switch(direction) 
        {
            case InputSwipeDirection.Up:
                CustomLog.Error($"Swipe Up");
                break;
            case InputSwipeDirection.Down:
                CustomLog.Error($"Swipe Down");
                break;
            case InputSwipeDirection.Left:
                CustomLog.Error($"Swipe Left");
                break;
            case InputSwipeDirection.Right:
                CustomLog.Error($"Swipe Right");
                break;
        }
    }

    // drag
    private void OnDragStared(Vector2 positionStart)
    {
        CustomLog.Trace($"OnDragStared");
    }

    private void OnDragPerformed(Vector2 delta)
    {
        // CustomLog.Trace($"OnDragPerformed");
    }

    private void OnDragCanceled(Vector2 positionEnd) 
    {
        CustomLog.Trace($"OnDragCanceled");
    }
}
