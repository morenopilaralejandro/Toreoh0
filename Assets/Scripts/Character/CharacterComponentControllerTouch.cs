using UnityEngine;
using Aremoreno.Enums.Input;

public abstract class CharacterComponentControllerTouch : MonoBehaviour
{
    // fields
    [SerializeField] private CharacterComponentRigidbody rb;
    [SerializeField] private CharacterComponentModel model;
    [SerializeField] private InputConfig inputConfig;

    protected bool isDragging;
    protected float inputSqrMagnitudeMin = 0.01f;
    protected float rotationSqrMagnitudeMin = 0.05f;
    protected float clampMagnitude = 40f;
    protected Vector2 tapPositionStart;
    protected Vector2 tapPositionEnd;
    protected Vector2 moveInput;
    protected Vector3 moveDirection;
    //protected Vector3 rotationDirection;

    // lifecycle
    /*
    public virtual void UpdateInternal() 
    {
        read movement input, targeting, other actions
    }
    */

    public virtual void FixedUpdateInternal() 
    {
        if (!CanMove()) return;
        if (!IsMoving()) return;
        UpdateMovement();
        UpdateRotation();
    }

    public virtual void LateUpdateInternal()
    {
        UpdateAnimation();
    }

    // logic
    protected virtual void UpdateMovement()
    {
        // if (!IsMoving()) return;
        rb.AddForce(moveDirection * GetSpeedMovement());
    }

    protected virtual void UpdateRotation()
    {
        // if (!IsRotating()) return;
        model.Rotate(moveDirection, GetSpeedRotation());
    }

    protected virtual void UpdateAnimation()
    {
        // if (!IsMoving()) return;
    }

    protected bool IsMoving() => isDragging && moveDirection.sqrMagnitude > inputSqrMagnitudeMin;
    //protected bool IsRotating() => moveDirection.sqrMagnitude > rotationSqrMagnitudeMin;


    protected abstract bool CanMove();
    protected abstract bool CanAct();
    protected abstract float GetSpeedMovement();
    protected abstract float GetSpeedRotation();
    protected abstract float GetAcceleration();

    // action
    protected abstract void ExecuteActionTap();
    protected abstract void ExecuteActionSwipeUp();
    protected abstract void ExecuteActionSwipeDown();
    protected abstract void ExecuteActionSwipeLeft();
    protected abstract void ExecuteActionSwipeRight();
    
    // event
    protected virtual void OnEnable()
    {
        InputManager.Instance.MapTouch.OnSwipePerformed += OnSwipePerformed;

        InputManager.Instance.MapTouch.OnDragStared += OnDragStared;
        InputManager.Instance.MapTouch.OnDragPerformed += OnDragPerformed;
        InputManager.Instance.MapTouch.OnDragCanceled += OnDragCanceled;
    }

    protected virtual void OnDisable()
    {
        InputManager.Instance.MapTouch.OnSwipePerformed -= OnSwipePerformed;

        InputManager.Instance.MapTouch.OnDragStared -= OnDragStared;
        InputManager.Instance.MapTouch.OnDragPerformed -= OnDragPerformed;
        InputManager.Instance.MapTouch.OnDragCanceled -= OnDragCanceled;
    }

    // swipe
    private void OnSwipePerformed(InputSwipeDirection direction) 
    {
        if (!CanAct()) return;
        switch(direction) 
        {
            case InputSwipeDirection.Up:
                ExecuteActionSwipeUp();
                break;
            case InputSwipeDirection.Down:
                ExecuteActionSwipeDown();
                break;
            case InputSwipeDirection.Left:
                ExecuteActionSwipeLeft();
                break;
            case InputSwipeDirection.Right:
                ExecuteActionSwipeRight();
                break;
        }
    }

    protected virtual void OnDragStared(Vector2 positionStart)
    {
        tapPositionStart = positionStart;
        isDragging = true;
    }

    protected virtual void OnDragPerformed(Vector2 delta)
    {
        //moveInput = delta;
        if (!isDragging) return;
        moveInput = (InputManager.Instance.MapTouch.PointerPosition - tapPositionStart);
        moveDirection = new Vector3(moveInput.x, moveInput.y, 0f);
        moveDirection = Vector3.ClampMagnitude(moveDirection, clampMagnitude);
        // rotationDirection = new Vector3(moveDirection.x, -moveDirection.y, 0f);
        // like this but reversed (changes y instead of z)  new Vector3(moveDirection.x, 0f, moveDirection.y);
    }

    protected virtual void OnDragCanceled(Vector2 positionEnd)
    {
        isDragging = false;
        moveInput = Vector2.zero;
        moveDirection = Vector3.zero;
        tapPositionEnd = positionEnd;
        float tapDistance = Vector2.Distance(tapPositionStart, tapPositionEnd);
        if (tapDistance <= inputConfig.TapDistanceMax && CanAct()) ExecuteActionTap();
    }
}
