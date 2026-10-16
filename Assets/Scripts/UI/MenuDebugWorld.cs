using UnityEngine;
using Aremoreno.Enums.Input;

public class MenuDebugWorld : Menu
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

    public void OnButtonBackClicked() 
    {
        RequestClose();
    }

    public void OnButtonOpenClicked() 
    {
        OnMenuDebugWorldOpenRequested();
    }

    public void OnButtonNoClipClicked()
    {

    }

    public void OnButtonToDebugClicked() 
    {
        RequestClose();
        SceneLoaderManager.Instance.UnloadGroup("SceneGroupData-World");
        SceneLoaderManager.Instance.LoadGroup("SceneGroupData-DebugMainMenu");
    }

    // Event
    protected override void OnEnable() 
    {
        base.OnEnable();
        UIEvents.OnMenuDebugWorldOpenRequested += OnMenuDebugWorldOpenRequested;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        UIEvents.OnMenuDebugWorldOpenRequested -= OnMenuDebugWorldOpenRequested;
    }

    private void OnMenuDebugWorldOpenRequested() => MenuManager.Instance.OpenMenu(this);
}
