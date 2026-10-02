using UnityEngine;
using Aremoreno.Enums.Display;

public class DisplayCamera : MonoBehaviour
{
    public DisplayScreen DisplayScreen;
    public Camera CameraObject { get; private set; }

    private void Start() 
    {
        CameraObject = GetComponent<Camera>();
        DisplayManager.Instance?.RegisterCamera(this);
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
        if (DisplayManager.Instance == null) return;
        CameraObject.targetDisplay = DisplayManager.Instance.GetTargetDisplay(DisplayScreen);
        CameraObject.rect = DisplayManager.Instance.GetRect(DisplayScreen);
    }
}
