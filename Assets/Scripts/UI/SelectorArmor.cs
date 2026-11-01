using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Aremoreno.Enums.Input;

public class SelectorArmor : Selector<Armor, SelectorArmorListItem>
{
    // fields
    //[Header("IU")]
    //[SerializeField] private TMP_Text textName;

    // override
    public override void OnOpened() 
    {
        //UIEvents.RaiseArmorOverviewUpdateRequested(null);
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
        UIEvents.OnSelectorArmorOpenRequested += OnSelectorArmorOpenRequested;
    }

    protected override void OnDisable() 
    {
        base.OnDisable();
        UIEvents.OnSelectorArmorOpenRequested -= OnSelectorArmorOpenRequested;
    }

    private void OnSelectorArmorOpenRequested(
        ISelectorSource<Armor> source, 
        ISelectorActionClick<Armor> actionClick, 
        ISelectorFilter<Armor> filter) 
    {
        Open(source, actionClick, filter);
    }
}
