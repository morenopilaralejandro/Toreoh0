public class SelectorDialogChoice : Selector<DialogSerializableChoice, SelectorDialogChoiceListItem>
{
    // fields
    //[Header("Visuals")]
    //[SerializeField] private int intValue;

    // override

    // input
    protected override void OnGainedInput() => InputManager.Instance.Dialog.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.Dialog.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputDialog input)
    {
        if (input = InputDialog.Choose) OnButtonChooseClicked();
        else if (input = InputDialog.Cancel) OnButtonCancelClicked();
    }

    public void OnButtonChooseClicked() 
    {
        raise the current selcted
        var choice = ;
        DialogEvents.RaiseChoiceSelected(choice.ChoiceIndex);
        RequestClose();
    }

    public void OnButtonCancelClicked() 
    {
        raise the last one
        var choice = ;
        DialogEvents.RaiseChoiceSelected(choice.ChoiceIndex);
        RequestClose();
    }

    // event
    protected override void OnEnable() 
    {
        base.OnEnable();
        DialogEvents.OnChoicesReady += OnChoicesReady;
    }

    protected override void OnDisable() 
    {
        base.OnDisable();
        DialogEvents.OnChoicesReady -= OnChoicesReady;
    }

    private void OnChoicesReady(List<DialogSerializableChoice> choices) 
    {
        Open(
            new SelectorDialogChoiceSource(choices),
            new SelectorDialogChoiceAction(),
            null
        );
    }
}
