using UnityEngine;
using Aremoreno.Enums.Display;

public class DisplayCanvas : MonoBehaviour
{
    public DisplayScreen DisplayScreen;
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform rectTransformDebug;

    private DisplayManager displayManager;

    private void Awake() 
    {
        rectTransformDebug.offsetMin = Vector2.zero;
        rectTransformDebug.offsetMax = Vector2.zero;
        displayManager = DisplayManager.Instance;
        if (displayManager != null) OnDisplayRefreshRequested();
    }
    
    // event
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
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = displayManager.GetCamera(DisplayScreen);
        canvas.targetDisplay = displayManager.GetTargetDisplay(DisplayScreen);;
    }
}
