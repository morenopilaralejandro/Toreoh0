using UnityEngine;
using TMPro;
using Aremoreno.Enums.Input;

public class MenuBattleCommand : Menu
{
    // rename to MenuBattleCommand open selectors
    // TODO other menu for MenuBattleSettigns open selectors
    // TODO put forfeit on the cornet
    // asist only one per match

    [Header("UI References")]
    [SerializeField] private BarUI barMpSelectorMove;
    [SerializeField] private TMP_Text textMpBattleSelectorMove;
    [SerializeField] private TMP_Text textMpTrueSelectorMove;

    private CharacterEntityBattle entity;
    private SelectorMoveSourceLearned sourceMove;
    private SelectorMoveActionClickPerform actionMove;
    private SelectorMoveFilterSpecial filterMove;


    // Lifecycle
    public override void OnOpened() => BattleManager.Instance.Battle.BattleComponentPause.Pause();
    public override void OnClosed() => BattleManager.Instance.Battle.BattleComponentPause.Resume();

    // Input
    protected override void OnGainedInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputNavigation input)
    {
        if (input == InputNavigation.Back) OnButtonBackClicked();
    }

    public void OnButtonBackClicked() => RequestClose();

    // button
    public void OnButtonMoveClicked() 
    {
        barMpSelectorMove.SetValue(entity.Character.CharacterComponentStatsMp.GetMpNormalized(), isInstant : true);
        textMpBattleSelectorMove.text = entity.Character.CharacterComponentStatsMp.BattleMp.ToString();
        textMpTrueSelectorMove.text = entity.Character.CharacterComponentStatsMp.TrueMp.ToString();

        UIEvents.RaiseSelectorMoveOpenRequested(sourceMove, actionMove, filterMove);
    } 

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
