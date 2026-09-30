public class DisplayCanvas : MonoBehaviour
{
    [SerializeField] private DisplayScreen displayScreen;
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTranform rectTranformDebug;

    private DisplayManager displayManager;

    private void Awake() 
    {
        rectTranformDebug.offsetMin = Vector2.zero;
        rectTranformDebug.offsetMax = Vector2.zero;
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
        var camera = displayManager.GetCamera(displayScreen);
        canvas.targetDisplay = camera.targetDisplay;
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = camera;
    }
}
