using UnityEngine;

[CreateAssetMenu(fileName = "PersistenceConfig", menuName = "ScriptableObject/Persistence/PersistenceConfig")]
public class PersistenceConfig : ScriptableObject
{
    [Header("Save Settings")]
    public bool IsAutoSaveEnabled;
    public bool IsSaveFileCompressionEnabled;
    public bool IsPrettyPrint;
    public int SaveSlotCount;

    [Header("Path")]
    public string Path;
    public string FileNamePrefix;
    public string FileNameSeparator;
    public string FileNameDefault;
    public string FileNameEmergency;
    public string FileNameTemp;

    [Header("SaveDataHeader")]
    public int SaveFormatVersion;
    public uint FileSignature;
    public string GameIdetifier;
}
