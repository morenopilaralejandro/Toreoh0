using UnityEngine;
using Aremoreno.Enums.Input;

public class MenuBattleCommand : Menu
{
    // rename to MenuBattleCommand open selectors
    // TODO other menu for MenuBattleSettigns open selectors
    // TODO put forfeit on the cornet
    // asist only one per match

    //[Header("UI References")]
    //[SerializeField] private DialogBoxUI dialogBox;
    private CharacterEntityBattle entity;
    private SelectorMoveSourceLearned sourceMove;
    private SelectorMoveActionClickPerform actionMove;
    private SelectorMoveFilterSpecial filterMove;

    // Lifecycle

    // Input
    protected override void OnGainedInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputNavigation input)
    {
        if (input == InputNavigation.Back) OnButtonBackClicked();
    }

    public void OnButtonBackClicked() => RequestClose();

    // button
    public void OnButtonMoveClicked() => UIEvents.RaiseSelectorMoveOpenRequested(sourceMove, actionMove, filterMove);

    // Event
    protected override void OnEnable()
    {
        base.OnEnable();
        UIEvents.OnMenuBattleCommandOpenRequested += OnMenuBattleCommandOpenRequested;
        UIEvents.OnMenuBattleCommandCloseRequested += OnMenuBattleCommandCloseRequested;
        UIEvents.OnMenuBattleCommandInitializeRequested += OnMenuBattleCommandInitializeRequested;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        UIEvents.OnMenuBattleCommandOpenRequested -= OnMenuBattleCommandOpenRequested;
        UIEvents.OnMenuBattleCommandCloseRequested -= OnMenuBattleCommandCloseRequested;
        UIEvents.OnMenuBattleCommandInitializeRequested -= OnMenuBattleCommandInitializeRequested;
    }

    private void OnMenuBattleCommandOpenRequested() => MenuManager.Instance.OpenMenu(this);
    private void OnMenuBattleCommandCloseRequested() => RequestClose();

    private void OnMenuBattleCommandInitializeRequested(CharacterEntityBattle entity)
    {
        this.entity = entity;
        sourceMove = new SelectorMoveSourceLearned(entity.Character);
        actionMove = new SelectorMoveActionClickPerform(entity);
        filterMove = new SelectorMoveFilterSpecial();
    }
}
