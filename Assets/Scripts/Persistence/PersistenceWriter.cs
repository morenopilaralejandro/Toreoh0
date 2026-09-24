using UnityEngine;
using System.IO;

public class PersistenceWriter
{
    private PersistenceConfig config;
    private string pathDefault;
    private string pathEmergency;
    private string pathTemp;
    private string pathDefaultCompressed;
    private string pathEmergencyCompressed;

    public PersistenceWriter(int slotIndex, PersistenceConfig config)
    {
        this.config = config;
        pathDefault = Path.Combine(
            Application.persistentDataPath, 
            $"{config.Path}/{config.FileNamePrefix}{config.FileNameSeparator}{slotIndex}{config.FileNameSeparator}{config.FileNameDefault}.json");
        pathEmergency = Path.Combine(
            Application.persistentDataPath, 
            $"{config.Path}/{config.FileNamePrefix}{config.FileNameSeparator}{slotIndex}{config.FileNameSeparator}{config.FileNameEmergency}.json");
        pathTemp = Path.Combine(
            Application.persistentDataPath, 
            $"{config.Path}/{config.FileNamePrefix}{config.FileNameSeparator}{slotIndex}{config.FileNameSeparator}{config.FileNameTemp}.json");

        pathDefaultCompressed = Path.Combine(
            Application.persistentDataPath, 
            $"{config.Path}/{config.FileNamePrefix}{config.FileNameSeparator}{slotIndex}{config.FileNameSeparator}{config.FileNameDefault}.gz");
        pathEmergencyCompressed = Path.Combine(
            Application.persistentDataPath, 
            $"{config.Path}/{config.FileNamePrefix}{config.FileNameSeparator}{slotIndex}{config.FileNameSeparator}{config.FileNameEmergency}.gz");
    }

    public bool TryWriteSaveData(SaveData saveData) 
    {
        if (!PersistenceValidator.IsValidSaveData(saveData)) return false;
        WriteSaveData(saveData);
        return true;
    }

    private void WriteSaveData(SaveData saveData) 
    {
        string json = JsonUtility.ToJson(saveData, config.IsPrettyPrint);
   
        // create temp
        File.WriteAllText(pathTemp, json);

        // create emergency from previous save data
        if(File.Exists(pathDefault))
            File.Copy(pathDefault, pathEmergency, overwrite : true);
        
        // replace save with temp
        File.Copy(pathTemp, pathDefault, overwrite : true);
        File.Delete(pathTemp);

        if (!config.IsSaveFileCompressionEnabled) return;
        FileCompressor.Compress(pathDefault, pathDefaultCompressed);
        FileCompressor.Compress(pathEmergency, pathEmergencyCompressed);
        File.Delete(pathDefault);
        File.Delete(pathEmergency);
    }

    private bool TryReadSaveDataAtPath(string path, out SaveData saveData) 
    {
        saveData = null;
        if (!File.Exists(path)) return false;

        try
        {
            string json = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(json);
            return saveData != null;
        }
        catch 
        {
            return false;
        }
    }

    //public bool HasSaveData() => File.Exists(pathDefault) || File.Exists(pathEmergency); Fast version

    public bool TryGetLastSaveData(out SaveData saveData, bool needsValidation = true)
    {
        saveData = null;

        if(config.IsSaveFileCompressionEnabled) 
        {
            if (File.Exists(pathDefaultCompressed)) FileCompressor.Decompress(pathDefaultCompressed, pathDefault);
            if (File.Exists(pathEmergencyCompressed)) FileCompressor.Decompress(pathEmergencyCompressed, pathEmergency);
        }

        if (!TryReadSaveDataAtPath(pathDefault, out saveData))
            if (!TryReadSaveDataAtPath(pathEmergency, out saveData)) 
                return false;
        if (needsValidation && (saveData == null || !PersistenceValidator.IsValidSaveData(saveData))) return false;
        return true;
    }
}
