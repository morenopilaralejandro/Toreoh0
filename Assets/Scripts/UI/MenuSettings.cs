using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Aremoreno.Enums.Input;

public class MenuSettings : Menu
{
    [Header("UI References - Audio")]
    [SerializeField] private Slider sliderBgm;
    [SerializeField] private Slider sliderSfx;
    [Header("UI References - Video")]
    [SerializeField] private Toggle toggleScreenFlipped;
    [SerializeField] private Toggle toggleDisplayAutoDetect;
    [SerializeField] private TMP_Dropdown dropdownDisplayMode;

    private Settings cachedSettings;
    private SettingsManager settingsManager;

    // Lifecycle
    protected override void Start() 
    {
        base.Start();
        settingsManager = SettingsManager.Instance;
        AddListeners();
        menuManager.OpenMenu(this);
    }

    public override void OnOpened() 
    {
        cachedSettings = settingsManager.CopyComponent.GetCopy();
        SetValues();
    }

    // Input
    protected override void OnGainedInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputNavigation input)
    {
        if (input == InputNavigation.Back) OnButtonBackClicked();
    }

    public void OnButtonBackClicked()
    {
        settingsManager.PersistenceComponent.Overwrite(cachedSettings);
        settingsManager.PersistenceComponent.Export();
        SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-MainMenu");
    }

    public void OnButtonSaveClicked()
    {
        settingsManager.PersistenceComponent.Export();
        SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-MainMenu");
    }

    // Input settings
    private void SetValues() 
    {
        sliderBgm.SetValueWithoutNotify(cachedSettings.Common.VolumeBgm);
        sliderSfx.SetValueWithoutNotify(cachedSettings.Common.VolumeSfx);
        toggleScreenFlipped.SetIsOnWithoutNotify(cachedSettings.Common.IsScreenFlipped);
        toggleDisplayAutoDetect.SetIsOnWithoutNotify(cachedSettings.Common.IsDisplayAutoDetect);
        dropdownDisplayMode.SetValueWithoutNotify((int) cachedSettings.Common.DisplayMode);
    }

    private void AddListeners() 
    {
        sliderBgm.onValueChanged.AddListener(settingsManager.SetterComponent.SetVolumeBgm);
        sliderSfx.onValueChanged.AddListener(settingsManager.SetterComponent.SetVolumeSfx);
        toggleScreenFlipped.onValueChanged.AddListener(settingsManager.SetterComponent.SetIsScreenFlipped);
        toggleDisplayAutoDetect.onValueChanged.AddListener(settingsManager.SetterComponent.SetIsDisplayAutoDetect);
        dropdownDisplayMode.onValueChanged.AddListener(settingsManager.SetterComponent.SetDisplayMode);
    }
}
