using Aremoreno.Enums.Display;
using Aremoreno.Enums.Input;
using Aremoreno.Enums.Localization;

public class SettingsManagerComponentSetter
{
    private SettingsManager manager;

    public SettingsManagerComponentSetter(SettingsManager manager)
    {
        this.manager = manager;
    }

    // Common
    public void SetVolumeBgm(float volume) 
    {
        manager.Settings.Common.VolumeBgm = volume;
        SettingsEvents.RaiseVolumeBgmChanged(volume);
    }

    public void SetVolumeSfx(float volume) 
    {
        manager.Settings.Common.VolumeSfx = volume;
        SettingsEvents.RaiseVolumeSfxChanged(volume);
    }

    public void SetLanguage(int localeIndex) 
    {
        manager.Settings.Common.LocaleIndex = localeIndex;
        SettingsEvents.RaiseLanguageChanged(localeIndex);
    }

    public void SetLocalizationStyle(LocalizationStyle style) 
    {
        manager.Settings.Common.LocalizationStyle = style;
        SettingsEvents.RaiseLocalizationStyleChanged(style);
    }

    public void SetIsScreenFlipped(bool isScreenFlipped) 
    {
        manager.Settings.Common.IsScreenFlipped = isScreenFlipped;
        SettingsEvents.RaiseIsScreenFlippedChanged(isScreenFlipped);
    }

    public void SetIsDisplayAutoDetect(bool isDisplayAutoDetect) 
    {
        manager.Settings.Common.IsDisplayAutoDetect = isDisplayAutoDetect;
        SettingsEvents.RaiseIsDisplayAutoDetectChanged(isDisplayAutoDetect);
    }

    public void SetDisplayMode(DisplayMode displayMode) 
    {
        manager.Settings.Common.DisplayMode = displayMode;
        SettingsEvents.RaiseDisplayModeChanged(displayMode);
    }

    public void SetControlSchemeCustom(ControlSchemeCustom controlSchemeCustom) 
    {
        manager.Settings.Common.ControlSchemeCustom = controlSchemeCustom;
        SettingsEvents.RaiseControlSchemeCustomChanged(controlSchemeCustom);
    }

    // Control Traditional

    // Control Touch

}
