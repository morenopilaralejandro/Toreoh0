using UnityEngine;
using System.IO;
using Aremoreno.Enums.Display;
using Aremoreno.Enums.Input;
using Aremoreno.Enums.Localization;

public class SettingsManager : MonoBehaviour 
{
    public static SettingsManager Instance { get; private set; }
    
    [SerializeField] private SettingsConfig config;
    public Settings Settings { get; private set; }
    private string filePath;

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

    public void Start() 
    {
        Initialize();
    }

    public void Initialize() 
    {
        filePath = Path.Combine(Application.persistentDataPath, $"{config.SettingsFilePath}/{config.SettingsFileName}.json");
        LoadSettings();
    }

    // Persistence
    public void LoadSettings() 
    {
        if (File.Exists(filePath)) 
        {
            var json = File.ReadAllText(filePath);
            Settings = JsonUtility.FromJson<Settings>(json);
        }
        else 
        {
            Settings = config.PresetDefault;
        }
        SettingsEvents.RaiseSettingsLoadEnded(Settings);
    }

    public void SaveSettings() 
    {
        File.WriteAllText(filePath, JsonUtility.ToJson(Settings, true));
    }

    // Common
    public void SetVolumeBgm(float volume) 
    {
        Settings.Common.VolumeBgm = volume;
        SettingsEvents.RaiseVolumeBgmChanged(volume);
    }

    public void SetVolumeSfx(float volume) 
    {
        Settings.Common.VolumeSfx = volume;
        SettingsEvents.RaiseVolumeSfxChanged(volume);
    }

    public void SetLanguage(int localeIndex) 
    {
        Settings.Common.LocaleIndex = localeIndex;
        SettingsEvents.RaiseLanguageChanged(localeIndex);
    }

    public void SetLocalizationStyle(LocalizationStyle style) 
    {
        Settings.Common.LocalizationStyle = style;
        SettingsEvents.RaiseLocalizationStyleChanged(style);
    }

    public void SetIsScreenFlipped(bool isScreenFlipped) 
    {
        Settings.Common.IsScreenFlipped = isScreenFlipped;
        SettingsEvents.RaiseIsScreenFlippedChanged(isScreenFlipped);
    }

    public void SetIsDisplayAutoDetect(bool isDisplayAutoDetect) 
    {
        Settings.Common.IsDisplayAutoDetect = isDisplayAutoDetect;
        SettingsEvents.RaiseIsDisplayAutoDetectChanged(isDisplayAutoDetect);
    }

    public void SetDisplayMode(DisplayMode displayMode) 
    {
        Settings.Common.DisplayMode = displayMode;
        SettingsEvents.RaiseDisplayModeChanged(displayMode);
    }

    public void SetControlSchemeCustom(ControlSchemeCustom controlSchemeCustom) 
    {
        Settings.Common.ControlSchemeCustom = controlSchemeCustom;
        SettingsEvents.RaiseControlSchemeCustomChanged(controlSchemeCustom);
    }

    // Control Traditional

    // Control Touch
}
