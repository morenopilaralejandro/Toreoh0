using UnityEngine;
using Aremoreno.Enums.Battle;
using Aremoreno.Enums.Input;

public class MenuBattleResult : Menu
{
    //[Header("UI References")]
    //[SerializeField] private DialogBoxUI dialogBox;
    private BattleResult battleResult;

    // Lifecycle
    protected override void Start() 
    {
        base.Start();
        if (BattleArgs.BattleResultSaveData == null) return;
        battleResult = new BattleResult(BattleArgs.BattleResultSaveData);
        menuManager.OpenMenu(this);
    }

    // Input
    protected override void OnGainedInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputNavigation input)
    {
        //if (input == InputNavigation.Back) OnButtonBackClicked();
    }

    //public void OnButtonBackClicked() => RequestClose();

    public void OnButtonContinueClicked()
    {
        //SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-DebugMainMenu");
        switch (battleResult.BattleResultComponentAttributes.BattleResultContinueType)
        {
            case BattleResultContinueType.Test:
                SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-MainMenu");
                break;
        }
    }
}
