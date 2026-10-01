using UnityEngine;
using Aremoreno.Enums.Display;

public class DisplayCamera : MonoBehaviour
{
    public DisplayScreen DisplayScreen;
    public Camera CameraObject { get; private set; }

    private DisplayManager displayManager;

    private void Start() 
    {
        CameraObject = GetComponent<Camera>();
        displayManager = DisplayManager.Instance;
        if (displayManager != null) displayManager.RegisterCamera(this);
    }

    private void OnEnable()
    {
        DisplayEvents.OnDisplayRefreshRequested += OnDisplayRefreshRequested;
    }

    private void OnDisable()
    {
        DisplayEvents.OnDisplayRefreshRequested -= OnDisplayRefreshRequested;
    }

    private void OnDisplayRefreshRequested()
    {
        CameraObject.targetDisplay = displayManager.GetTargetDisplay(DisplayScreen);
        CameraObject.rect = displayManager.GetRect(DisplayScreen);
    }
}
