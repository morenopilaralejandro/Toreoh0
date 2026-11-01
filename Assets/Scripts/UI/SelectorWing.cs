using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Aremoreno.Enums.Input;

public class SelectorWing : Selector<Wing, SelectorWingListItem>
{
    // fields
    //[Header("IU")]
    //[SerializeField] private TMP_Text textName;

    // override
    public override void OnOpened() 
    {
        //UIEvents.RaiseWingOverviewUpdateRequested(null);
        base.OnOpened();
    }

    // input
    protected override void OnGainedInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputNavigation input)
    {
        if (input == InputNavigation.Back) OnButtonBackClicked();
    }

    public void OnButtonBackClicked() => RequestClose();
    public void OnButtonConfirmClicked() => OnClicked(lastSelectedElement);

    // event
    protected override void OnEnable()
    {
        base.OnEnable();
        UIEvents.OnSelectorWingOpenRequested += OnSelectorWingOpenRequested;
    }

    protected override void OnDisable() 
    {
        base.OnDisable();
        UIEvents.OnSelectorWingOpenRequested -= OnSelectorWingOpenRequested;
    }

    private void OnSelectorWingOpenRequested(
        ISelectorSource<Wing> source, 
        ISelectorActionClick<Wing> actionClick, 
        ISelectorFilter<Wing> filter) 
    {
        Open(source, actionClick, filter);
    }
}
