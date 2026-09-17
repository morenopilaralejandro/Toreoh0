using Aremoreno.Enums.Input;

public class InputActionMapDialog : InputActionMap<InputDialog>
{
    protected override void BindAll() 
    {
        Bind(inputActions.ActionsDialog.Continue, InputDialog.Continue);
        Bind(inputActions.ActionsDialog.Choose, InputDialog.Choose);
        Bind(inputActions.ActionsDialog.Cancel, InputDialog.Cancel);
    }

    public override void Enable() => inputActions.ActionsDialog.Enable();
    public override void Disable() => inputActions.ActionsDialog.Disable();
}
