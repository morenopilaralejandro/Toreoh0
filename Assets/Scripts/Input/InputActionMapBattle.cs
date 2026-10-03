using UnityEngine;
using UnityEngine.InputSystem;
using Aremoreno.Enums.Input;

public class InputActionMapBattle : InputActionMap<InputBattle>
{
    public Vector2 Move { get; private set; }

    protected override void BindAll() 
    {
        inputActions.ActionsBattle.Move.performed += OnMovePeformed;
        inputActions.ActionsBattle.Move.canceled += OnMoveCanceled;

        Bind(inputActions.ActionsBattle.Pass, InputBattle.Pass);
        Bind(inputActions.ActionsBattle.Shoot, InputBattle.Shoot);
    }

    public override void Enable() => inputActions.ActionsBattle.Enable();
    public override void Disable() => inputActions.ActionsBattle.Disable();

    private void OnMovePeformed(InputAction.CallbackContext context) => Move = context.ReadValue<Vector2>();
    private void OnMoveCanceled(InputAction.CallbackContext context) => Move = Vector2.zero;

    public override void Reset() 
    {
        base.Reset();
        Move = Vector2.zero;
    }
}
