using UnityEngine;
using UnityEngine.InputSystem;
using Aremoreno.Enums.Input;

public class InputActionMapWorld : InputActionMap<InputWorld>
{
    public Vector2 move { get; private set; }

    protected override void BindAll() 
    {
        inputActions.ActionsWorld.Move.performed += OnMovePeformed;
        inputActions.ActionsWorld.Move.canceled += OnMoveCanceled;

        Bind(inputActions.ActionsWorld.Run, InputWorld.Run);
        Bind(inputActions.ActionsWorld.Interact, InputWorld.Interact);
        Bind(inputActions.ActionsWorld.SideMenuOpen, InputWorld.SideMenuOpen);
    }

    public override void Enable() => inputActions.ActionsWorld.Enable();
    public override void Disable() => inputActions.ActionsWorld.Disable();

    private void OnMovePeformed(InputAction.CallbackContext context) => move = context.ReadValue<Vector2>();
    private void OnMoveCanceled(InputAction.CallbackContext context) => move = Vector2.zero;
}
