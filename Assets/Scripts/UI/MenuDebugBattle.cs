using UnityEngine;
using Aremoreno.Enums.Input;

public class MenuDebugBattle : Menu
{
    //[Header("UI References")]
    [SerializeField] private BattleConfig battleConfig;
    private bool isEnemyAIEnable;

    // Lifecycle
    protected override void Start() 
    {
        base.Start();
        isEnemyAIEnable = battleConfig.IsEnemyAIEnable;
    }

    // Input
    protected override void OnGainedInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputNavigation input)
    {
        if (input == InputNavigation.Back) OnButtonBackClicked();
    }

    public void OnButtonBackClicked() => RequestClose();
    public void OnButtonOpenClicked() => menuManager.OpenMenu(this);

    public void OnButtonForfeitClicked() 
    {
        BattleManager.Instance.Battle.BattleComponentEnd.EndByForfeit();
    }

    public void OnButtonToggleEnemyAIClicked() 
    {
        isEnemyAIEnable = !isEnemyAIEnable;
        BattleEvents.RaiseIsEnemyAiEnabledChanged(isEnemyAIEnable);
    }
}
