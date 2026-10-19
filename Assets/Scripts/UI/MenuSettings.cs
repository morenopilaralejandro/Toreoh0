using UnityEngine;
using Aremoreno.Enums.Input;

public class MenuSettings : Menu
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
        if (input == InputNavigation.Back) OnButtonBackClicked();
    }

    public void OnButtonBackClicked()
    {
        RequestClose();
        SceneLoaderManager.Instance.UnloadGroup("SceneGroupData-Credits");
        SceneLoaderManager.Instance.LoadGroup("SceneGroupData-MainMenu");
    }

    public void OnButtonSaveClicked()
    {
        RequestClose();
    }
}
