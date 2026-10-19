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

    //public void OnButtonBackClicked() => RequestClose();

    /*
    public void OnButtonStoryClicked()
    {
        RequestClose();
        SceneLoaderManager.Instance.UnloadGroup("SceneGroupData-World");
        SceneLoaderManager.Instance.LoadGroup("SceneGroupData-DebugMainMenu");
    }
    */

    public void OnButtonStoryClicked()
    {

        // TODO event save

        /*
        RequestClose();
        SceneLoaderManager.Instance.UnloadGroup("SceneGroupData-MainMenu");
        SceneLoaderManager.Instance.LoadGroup("SceneGroupData-World");
        */
    }

    public void OnButtonBattleClicked()
    {
        RequestClose();
        SceneLoaderManager.Instance.UnloadGroup("SceneGroupData-MainMenu");
        SceneLoaderManager.Instance.LoadGroup("SceneGroupData-Battle");
    }

    public void OnButtonSettingsClicked()
    {
        RequestClose();
        SceneLoaderManager.Instance.UnloadGroup("SceneGroupData-MainMenu");
        SceneLoaderManager.Instance.LoadGroup("SceneGroupData-Settings");
    }

    public void OnButtonCreditsClicked()
    {
        RequestClose();
        SceneLoaderManager.Instance.UnloadGroup("SceneGroupData-MainMenu");
        SceneLoaderManager.Instance.LoadGroup("SceneGroupData-Credits");
    }

    public void OnButtonQuitClicked() => Application.Quit();
}
