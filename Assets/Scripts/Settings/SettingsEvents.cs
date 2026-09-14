using System;

public static class SettingsEvents 
{
    public static event Action<float> OnVolumeBgmChanged;
    public static void RaiseVolumeBgmChanged(float volume) 
        => OnVolumeBgmChanged.Invoke(volume);

    public static event Action<float> OnVolumeSfxChanged;
    public static void RaiseVolumeSfxChanged(float volume) 
        => OnVolumeSfxChanged.Invoke(volume);
}
