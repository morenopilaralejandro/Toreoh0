public class SettingsManagerComponentCopy
{
    private SettingsManager manager;

    public SettingsManagerComponentCopy(SettingsManager manager)
    {
        this.manager = manager;
    }

    public Settings GetCopy() 
    {
        SettingsCommon common = new SettingsCommon
        {
            LocaleIndex = manager.Settings.Common.LocaleIndex,
            LocalizationStyle = manager.Settings.Common.LocalizationStyle,
            VolumeBgm = manager.Settings.Common.VolumeBgm,
            VolumeSfx = manager.Settings.Common.VolumeSfx,
            IsScreenFlipped = manager.Settings.Common.IsScreenFlipped,
            IsDisplayAutoDetect = manager.Settings.Common.IsDisplayAutoDetect,
            DisplayMode = manager.Settings.Common.DisplayMode,
            ControlSchemeCustom = manager.Settings.Common.ControlSchemeCustom
        };

        SettingsControlTraditional controlTraditional = new SettingsControlTraditional 
        {
            IsAutoPass = manager.Settings.ControlTraditional.IsAutoPass
        };

        SettingsControlTouch controlTouch = new SettingsControlTouch 
        {
            IsShootOnSwipe = manager.Settings.ControlTouch.IsShootOnSwipe
        };

        Settings copySettings = new Settings 
        {
            Common = common,
            ControlTraditional = controlTraditional,
            ControlTouch = controlTouch
        };

        return copySettings;
    }
}
