using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Aremoreno.Enums.Input;

public class SelectorMove : Selector<Move, SelectorMoveListItem>
{
    // fields
    //[Header("IU")]
    //[SerializeField] private TMP_Text textName;

    // override
    public override void OnOpened() 
    {
        //UIEvents.RaiseMoveOverviewUpdateRequested(null);
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
        UIEvents.OnSelectorMoveOpenRequested += OnSelectorMoveOpenRequested;
    }

    protected override void OnDisable() 
    {
        base.OnDisable();
        UIEvents.OnSelectorMoveOpenRequested -= OnSelectorMoveOpenRequested;
    }

    private void OnSelectorMoveOpenRequested(
        ISelectorSource<Move> source, 
        ISelectorActionClick<Move> actionClick, 
        ISelectorFilter<Move> filter) 
    {
        Open(source, actionClick, filter);
    }
}
