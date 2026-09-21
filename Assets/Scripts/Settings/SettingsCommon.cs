using Aremoreno.Enums.Input;
using Aremoreno.Enums.Localization;

[System.Serializable]
public class SettingsCommon
{
    public int LocaleIndex = 0;
    public LocalizationStyle LocalizationStyle = LocalizationStyle.Localized;
    public float VolumeBgm = 1f;
    public float VolumeSfx = 1f;
    public ControlSchemeCustom ControlSchemeCustom = ControlSchemeCustom.Traditional;
}
