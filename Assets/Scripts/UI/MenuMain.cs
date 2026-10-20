using UnityEngine;
using Aremoreno.Enums.Input;

public class MenuMain : Menu
{
    //[Header("UI References")]
    //[SerializeField] private DialogBoxUI dialogBox;

    // Lifecycle
    protected override void Start() 
    {
        base.Start();
        menuManager.OpenMenu(this);
    }

    // Input
    protected override void OnGainedInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputNavigation input)
    {
        //if (input == InputNavigation.Back) OnButtonBackClicked();
    }

    public void OnButtonStoryClicked()
    {

        // TODO event save

    }

    public void OnButtonBattleClicked() => SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-Battle");
    public void OnButtonSettingsClicked() => SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-Settings");
    public void OnButtonCreditsClicked() => SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-Credits");
    public void OnButtonQuitClicked() => Application.Quit();
}
