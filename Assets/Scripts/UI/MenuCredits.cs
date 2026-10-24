using UnityEngine;
using Aremoreno.Enums.Input;

public class MenuCredits : Menu
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

    public void OnButtonBackClicked() => SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-MainMenu");
}
