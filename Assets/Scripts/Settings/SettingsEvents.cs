using System;
using Aremoreno.Enums.Localization;

public static class SettingsEvents 
{
    public static event Action<float> OnVolumeBgmChanged;
    public static void RaiseVolumeBgmChanged(float volume) 
        => OnVolumeBgmChanged.Invoke(volume);

    public static event Action<float> OnVolumeSfxChanged;
    public static void RaiseVolumeSfxChanged(float volume) 
        => OnVolumeSfxChanged.Invoke(volume);

    public static event Action<int> OnLanguageChanged;
    public static void RaiseLanguageChanged(int localeIndex) 
        => OnLanguageChanged.Invoke(localeIndex);

    public static event Action<LocalizationStyle> OnLocalizationStyleChanged;
    public static void RaiseLocalizationStyleChanged(LocalizationStyle localizationStyle) 
        => OnLocalizationStyleChanged.Invoke(localizationStyle);
}
