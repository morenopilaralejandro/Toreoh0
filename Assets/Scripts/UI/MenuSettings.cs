using UnityEngine;
using UnityEngine.UI;
using Aremoreno.Enums.Input;

public class MenuSettings : Menu
{
    [Header("UI References - Audio")]
    [SerializeField] private Slider sliderBgm;
    [SerializeField] private Slider sliderSfx;
    [Header("UI References - Video")]
    [SerializeField] private Toggle toggleScreenFlipped;
    [SerializeField] private Toggle toggleDisplayAutoDetect;

    private Settings cachedSettings;
    private SettingsManager settingsManager;

    // Lifecycle
    protected override void Start() 
    {
        base.Start();
        settingsManager = SettingsManager.Instance;
        menuManager.OpenMenu(this);
    }

    public override void OnOpened() 
    {
        cachedSettings = settingsManager.CopyComponent.GetCopy();
        SetValues();
        AddListeners();
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
    private void AddListeners() 
    {
        sliderBgm.onValueChanged.AddListener(settingsManager.SetterComponent.SetVolumeBgm);
        sliderSfx.onValueChanged.AddListener(settingsManager.SetterComponent.SetVolumeSfx);
        toggleScreenFlipped.onValueChanged.AddListener(settingsManager.SetterComponent.SetIsScreenFlipped);
        //toggleDisplayAutoDetect.onValueChanged.AddListener(settingsManager.SetIsDisplayAutoDetect);
    }

    private void SetValues() 
    {
        sliderBgm.value = cachedSettings.Common.VolumeBgm;
        sliderSfx.value = cachedSettings.Common.VolumeSfx;
        toggleScreenFlipped.isOn = cachedSettings.Common.IsScreenFlipped;
    }
}
