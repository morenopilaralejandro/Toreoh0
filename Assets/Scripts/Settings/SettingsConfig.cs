using UnityEngine;

[CreateAssetMenu(fileName = "SettingsConfigDefault", menuName = "ScriptableObject/Settings/SettingsConfigDefault")]
public class SettingsConfig : ScriptableObject
{
    [Header("Path")]
    public string Folder;
    public string FileName;
    public bool IsCompressionEnabled;
    public bool IsPrettyPrint;

    [Header("Preset")]
    public Settings PresetDefault;
}
