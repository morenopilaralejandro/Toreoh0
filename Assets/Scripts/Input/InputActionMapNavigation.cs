using Aremoreno.Enums.Input;

public class InputActionMapNavigation : InputActionMap<InputNavigation>
{
    protected override void BindAll() 
    {
        Bind(inputActions.ActionsNavigation.Back, InputNavigation.Back);
    }

    public override void Enable() => inputActions.ActionsNavigation.Enable();
    public override void Disable() => inputActions.ActionsNavigation.Disable();
}
