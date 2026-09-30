public class DisplayCamera : MonoBehaviour
{
    [SerializeField] private DisplayScreen displayScreen;
    public Camera Camera { get; private set; }

    private DisplayManager displayManager;

    private void Start() 
    {
        displayManager = DisplayManager.Instance;
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
        camera.targetDisplay = displayManager.GetTargetDisplay(displayScreen);
        camera.rect = displayManager.GetRect(displayScreen);
    }
}
