using UnityEngine;
using UnityEngine.Localization.Tables;
using UnityEngine.Localization.Settings;
using Aremoreno.Enums.Localization;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance { get; private set; }
    [SerializeField] private LocalizationConfig config;
    [SerializeField] private LocalizationTableMappingConfig mappingConfig;
    [SerializeField] private SettingsManager settingsManager;
    
    private void Awake() 
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Initialize();
    }

    private void Initialize()
    {
        mappingConfig.Initialize();
    }

    public TableReference GetTableReference(LocalizationEntity entity, LocalizationField field) => 
        mappingConfig.GetTableReference(
            entity, 
            field, 
            settingsManager.Settings.Common.LocalizationStyle);

    // event
    private void OnEnable()
    {
        SettingsEvents.OnSettingsLoadEnded += OnSettingsLoadEnded;
        SettingsEvents.OnLanguageChanged += OnLanguageChanged;
    }

    private void OnDisable()
    {
        SettingsEvents.OnSettingsLoadEnded -= OnSettingsLoadEnded;
        SettingsEvents.OnLanguageChanged -= OnLanguageChanged;
    }

    private void OnLanguageChanged(int localeIndex) 
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeIndex];
    }

    private void OnSettingsLoadEnded(Settings settings) 
    {
        if (config.IsLocalizationEnabled)
            OnLanguageChanged(settings.Common.LocaleIndex);
        else 
            OnLanguageChanged(config.LocaleIndexDefault);
    }
}
