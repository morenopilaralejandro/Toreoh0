using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Aremoreno.Enums.Input;

public class SelectorWeapon : Selector<Weapon, SelectorWeaponListItem>
{
    // fields
    //[Header("IU")]
    //[SerializeField] private TMP_Text textName;

    // override
    public override void OnOpened() 
    {
        //UIEvents.RaiseWeaponOverviewUpdateRequested(null);
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
        UIEvents.OnSelectorWeaponOpenRequested += OnSelectorWeaponOpenRequested;
    }

    protected override void OnDisable() 
    {
        base.OnDisable();
        UIEvents.OnSelectorWeaponOpenRequested -= OnSelectorWeaponOpenRequested;
    }

    private void OnSelectorWeaponOpenRequested(
        ISelectorSource<Weapon> source, 
        ISelectorActionClick<Weapon> actionClick, 
        ISelectorFilter<Weapon> filter) 
    {
        Open(source, actionClick, filter);
    }
}
