using System.Collections.Generic;
using Aremoreno.Enums.Input;

public class SelectorDialogChoice : Selector<DialogSerializableChoice, SelectorDialogChoiceListItem>
{
    // fields
    //[Header("Visuals")]
    //[SerializeField] private int intValue;

    // override

    // input
    protected override void OnGainedInput() => InputManager.Instance.MapDialog.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.MapDialog.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputDialog input)
    {
        if (input == InputDialog.Choose) OnButtonChooseClicked();
        else if (input == InputDialog.Cancel) OnButtonCancelClicked();
    }

    public void OnButtonChooseClicked() 
    {
        var choice = GetSelectedElement()?.Data;
        if (choice == null) return; 
        DialogEvents.RaiseChoiceSelected(choice.ChoiceIndex);
        RequestClose();
    }

    public void OnButtonCancelClicked() 
    {
        var choice = ScrollAdapter.PoolWrapper.Pool.ActiveElements[ScrollAdapter.PoolWrapper.Pool.CountActive - 1].Data;
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
