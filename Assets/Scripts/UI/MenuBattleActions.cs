using UnityEngine;
using Aremoreno.Enums.Input;

public class MenuBattleActions : Menu
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

    public void OnButtonBackClicked() => RequestClose();

    // Event
    protected override void OnEnable()
    {
        base.OnEnable();
        UIEvents.OnMenuBattleActionsOpenRequested += OnMenuBattleActionsOpenRequested;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        UIEvents.OnMenuBattleActionsOpenRequested -= OnMenuBattleActionsOpenRequested;
    }

    private void OnMenuBattleActionsOpenRequested() => MenuManager.Instance.OpenMenu(this);
}
