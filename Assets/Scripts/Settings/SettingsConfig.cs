using UnityEngine;

[CreateAssetMenu(fileName = "SettingsConfigDefault", menuName = "ScriptableObject/Settings/SettingsConfigDefault")]
public class SettingsConfig : ScriptableObject
{
    [Header("Path")]
    public string SettingsFilePath;
    public string SettingsFileName;

    [Header("Preset")]
    public Settings PresetDefault;
}
