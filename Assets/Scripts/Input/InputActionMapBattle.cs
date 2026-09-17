using UnityEngine;
using UnityEngine.InputSystem;
using Aremoreno.Enums.Input;

public class InputActionMapBattle : InputActionMap<InputBattle>
{
    public Vector2 move { get; private set; }

    protected override void BindAll() 
    {
        inputActions.ActionsBattle.Move.performed += OnMovePeformed;
        inputActions.ActionsBattle.Move.canceled += OnMoveCanceled;

        Bind(inputActions.ActionsBattle.Pass, InputBattle.Pass);
        Bind(inputActions.ActionsBattle.Shoot, InputBattle.Shoot);
    }

    public override void Enable() => inputActions.ActionsBattle.Enable();
    public override void Disable() => inputActions.ActionsBattle.Disable();

    private void OnMovePeformed(InputAction.CallbackContext context) => move = context.ReadValue<Vector2>();
    private void OnMoveCanceled(InputAction.CallbackContext context) => move = Vector2.zero;

    public override void Reset() 
    {
        base.Reset();
        move = Vector2.zero;
    }
}
