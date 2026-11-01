using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Aremoreno.Enums.Input;

public class SelectorCharacter : Selector<Character, SelectorCharacterListItem>
{
    // fields
    //[Header("IU")]
    //[SerializeField] private TMP_Text textName;

    // override
    public override void OnOpened() 
    {
        //UIEvents.RaiseCharacterOverviewUpdateRequested(null);
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
        UIEvents.OnSelectorCharacterOpenRequested += OnSelectorCharacterOpenRequested;
    }

    protected override void OnDisable() 
    {
        base.OnDisable();
        UIEvents.OnSelectorCharacterOpenRequested -= OnSelectorCharacterOpenRequested;
    }

    private void OnSelectorCharacterOpenRequested(
        ISelectorSource<Character> source, 
        ISelectorActionClick<Character> actionClick, 
        ISelectorFilter<Character> filter) 
    {
        Open(source, actionClick, filter);
    }
}
