using UnityEngine;
using Aremoreno.Enums.Display;

public class DisplayManager : MonoBehaviour
{
    public static DisplayManager Instance { get; private set; }

    [SerializeField] private DisplayConfig config;

    public Camera CameraTop { get; private set; }
    public Camera CameraBottom { get; private set; }
    public int TargetDisplayTop { get; private set; }
    public int TargetDisplayBottom { get; private set; }
    public Rect RectTop { get; private set; }
    public Rect RectBottom { get; private set; }

    public bool IsScreenFlipped { get; private set; }
    public bool IsDisplayAutoDetect { get; private set; }
    public DisplayMode DisplayModeDefault { get; private set; }
    public DisplayMode DisplayModeCurrent { get; private set; }

    private void Awake() 
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // api
    public void RegisterCamera(DisplayCamera displayCamera) 
    {
        if (displayCamera.DisplayScreen == DisplayScreen.TopScreen) 
            CameraTop = displayCamera.CameraObject;
        else
            CameraBottom = displayCamera.CameraObject;

        if (CameraTop != null && CameraBottom != null) 
        {
            CheckAutoDetect();
            CacheDisplay();
        }
    }

    public Camera GetCamera(DisplayScreen displayScreen) => displayScreen == DisplayScreen.TopScreen ? CameraTop : CameraBottom;
    public int GetTargetDisplay(DisplayScreen displayScreen) => displayScreen == DisplayScreen.TopScreen ? TargetDisplayTop : TargetDisplayBottom;
    public Rect GetRect(DisplayScreen displayScreen) => displayScreen == DisplayScreen.TopScreen ? RectTop : RectBottom;

    // logic
    private void CacheDisplay()
    {
        // rect     only changes on single screen
        // target   only changes on double screen
        if(DisplayModeCurrent == DisplayMode.SingleScreen)
        {
            TargetDisplayTop = config.TargetDisplaySingle;
            TargetDisplayBottom = config.TargetDisplaySingle;
            RectTop = IsScreenFlipped ? config.RectBottomSingle : config.RectTopSingle;
            RectBottom = IsScreenFlipped ? config.RectTopSingle : config.RectBottomSingle;
        }
        else
        {
            TargetDisplayTop = IsScreenFlipped ? config.TargetDisplayBottomDouble : config.TargetDisplayTopDouble;
            TargetDisplayBottom = IsScreenFlipped ? config.TargetDisplayTopDouble : config.TargetDisplayBottomDouble;
            RectTop = config.RectDouble;
            RectBottom = config.RectDouble;
        }
        DisplayEvents.RaiseDisplayRefreshRequested();
    }

    private void CheckAutoDetect()
    {
        if (config.IsDebugDoubleScreen) 
        {
            DisplayModeCurrent = DisplayMode.DoubleScreen;
            return;
        }

        bool hasTwoRealScreens = Display.displays.Length == 2;
        if (hasTwoRealScreens)
            DisplayModeCurrent = IsDisplayAutoDetect ? DisplayModeDefault : DisplayMode.DoubleScreen;
        else
            DisplayModeCurrent = DisplayMode.SingleScreen;
    }

    // event
    private void OnEnable() 
    {
        SettingsEvents.OnIsScreenFlippedChanged += OnIsScreenFlippedChanged;
        SettingsEvents.OnIsDisplayAutoDetectChanged += OnIsDisplayAutoDetectChanged;
        SettingsEvents.OnDisplayModeChanged += OnDisplayModeChanged;
        SettingsEvents.OnSettingsLoadEnded += OnSettingsLoadEnded;
    }

    private void OnDisable() 
    {
        SettingsEvents.OnIsScreenFlippedChanged -= OnIsScreenFlippedChanged;
        SettingsEvents.OnIsDisplayAutoDetectChanged -= OnIsDisplayAutoDetectChanged;
        SettingsEvents.OnDisplayModeChanged -= OnDisplayModeChanged;
        SettingsEvents.OnSettingsLoadEnded -= OnSettingsLoadEnded;
    }

    private void OnIsScreenFlippedChanged(bool isScreenFlipped)
    {
        IsScreenFlipped = isScreenFlipped;
        CacheDisplay();
    }

    private void OnIsDisplayAutoDetectChanged(bool isDisplayAutoDetect) 
    {
        IsDisplayAutoDetect = isDisplayAutoDetect;
        CheckAutoDetect();
        CacheDisplay();
    }

    private void OnDisplayModeChanged(DisplayMode displayMode)
    {
        DisplayModeDefault = displayMode;
        CheckAutoDetect();
        CacheDisplay();
    }

    private void OnSettingsLoadEnded(Settings settings)
    {
        IsScreenFlipped = settings.Common.IsScreenFlipped;
        IsDisplayAutoDetect = settings.Common.IsDisplayAutoDetect;
        DisplayModeDefault = settings.Common.DisplayMode;
    }
}
