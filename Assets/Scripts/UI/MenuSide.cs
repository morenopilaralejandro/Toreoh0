using UnityEngine;
using Aremoreno.Enums.Input;

public class MenuSide : Menu
{
    //[Header("UI References")]
    //[SerializeField] private DialogBoxUI dialogBox;

    // Lifecycle

    // Input
    protected override void OnGainedInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputNavigation input)
    {
        if (input == InputNavigation.Back) OnButtonBackClicked();
    }

    public void OnButtonBackClicked() 
    {
        RequestClose();
    }

    public void OnButtonOpenClicked() 
    {
        OnMenuSideOpenRequested();
    }

    // Event
    protected override void OnEnable() 
    {
        base.OnEnable();
        UIEvents.OnMenuSideOpenRequested += OnMenuSideOpenRequested;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        UIEvents.OnMenuSideOpenRequested -= OnMenuSideOpenRequested;
    }

    private void OnMenuSideOpenRequested() => MenuManager.Instance.OpenMenu(this);
}
