using UnityEngine;
using Aremoreno.Enums.Input;

public class MenuBattleResult : Menu
{
    //[Header("UI References")]
    //[SerializeField] private DialogBoxUI dialogBox;

    // Lifecycle
    protected override void Awake() 
    {
        base.Awake();
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
    }
}
