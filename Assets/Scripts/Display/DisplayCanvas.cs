using UnityEngine;
using Aremoreno.Enums.Display;

public class DisplayCanvas : MonoBehaviour
{
    public DisplayScreen DisplayScreen;
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform rectTransformDebug;
    [SerializeField] private string sortingLayerName;

    private void Awake() 
    {
        rectTransformDebug.offsetMin = Vector2.zero;
        rectTransformDebug.offsetMax = Vector2.zero;
        OnDisplayRefreshRequested();
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
        if (DisplayManager.Instance == null) return;
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = DisplayManager.Instance.GetCamera(DisplayScreen);
        canvas.targetDisplay = DisplayManager.Instance.GetTargetDisplay(DisplayScreen);;
        canvas.sortingLayerName = sortingLayerName;
    }
}
