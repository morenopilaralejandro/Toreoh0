using System;
using Aremoreno.Enums.Display;
using Aremoreno.Enums.Input;
using Aremoreno.Enums.Localization;

public static class SettingsEvents 
{
    // generic
    public static event Action<Settings> OnSettingsLoadEnded;
    public static void RaiseSettingsLoadEnded(Settings settings) 
        => OnSettingsLoadEnded.Invoke(settings);

    // volume
    public static event Action<float> OnVolumeBgmChanged;
    public static void RaiseVolumeBgmChanged(float volume) 
        => OnVolumeBgmChanged.Invoke(volume);

    public static event Action<float> OnVolumeSfxChanged;
    public static void RaiseVolumeSfxChanged(float volume) 
        => OnVolumeSfxChanged.Invoke(volume);

    // localization
    public static event Action<int> OnLanguageChanged;
    public static void RaiseLanguageChanged(int localeIndex) 
        => OnLanguageChanged.Invoke(localeIndex);

    public static event Action<LocalizationStyle> OnLocalizationStyleChanged;
    public static void RaiseLocalizationStyleChanged(LocalizationStyle localizationStyle) 
        => OnLocalizationStyleChanged.Invoke(localizationStyle);

    // display
    public static event Action<bool> OnIsScreenFlippedChanged;
    public static void RaiseIsScreenFlippedChanged(bool isScreenFlipped) 
        => OnIsScreenFlippedChanged.Invoke(isScreenFlipped);

    public static event Action<bool> OnIsDisplayAutoDetectChanged;
    public static void RaiseIsDisplayAutoDetectChanged(bool isDisplayAutoDetect) 
        => OnIsDisplayAutoDetectChanged.Invoke(isDisplayAutoDetect);

    public static event Action<DisplayMode> OnDisplayModeChanged;
    public static void RaiseOnDisplayModeChanged(DisplayMode displayMode) 
        => OnDisplayModeChanged.Invoke(displayMode);

    // input
    public static event Action<ControlSchemeCustom> OnControlSchemeCustomChanged;
    public static void RaiseControlSchemeCustomChanged(ControlSchemeCustom controlSchemeCustom) 
        => OnControlSchemeCustomChanged.Invoke(controlSchemeCustom);
}
