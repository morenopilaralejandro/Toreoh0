using UnityEngine;
using System.IO;

public class PersistenceWriter
{
    private PersistenceConfig config;
    private FileWriterJson defaultWriter;
    private FileWriterJson emergencyWriter;
    private FileWriterJson tempWriter;
    public bool HasSaveData;

    public PersistenceWriter(int slotIndex, PersistenceConfig config)
    {
        this.config = config;
        FileValidatorBasic fileValidator = new FileValidatorBasic();

        defaultWriter = new FileWriterJson(
            pathFolder : IOUtils.PathCombinePersistent(config.Folder),
            pathFileName : $"{config.FileNamePrefix}{config.FileNameSeparator}{slotIndex}{config.FileNameSeparator}{config.FileNameDefault}",
            validator : fileValidator,
            isCompressionEnabled : config.IsSaveFileCompressionEnabled,
            isPrettyPrint : config.IsPrettyPrint
        );

        emergencyWriter = new FileWriterJson( 
            pathFolder : IOUtils.PathCombinePersistent(config.Folder), 
            pathFileName : $"{config.FileNamePrefix}{config.FileNameSeparator}{slotIndex}{config.FileNameSeparator}{config.FileNameEmergency}",
            validator : fileValidator,
            isCompressionEnabled : config.IsSaveFileCompressionEnabled,
            isPrettyPrint : config.IsPrettyPrint
        );

        tempWriter = new FileWriterJson( 
            pathFolder : IOUtils.PathCombinePersistent(config.Folder), 
            pathFileName : $"{config.FileNamePrefix}{config.FileNameSeparator}{slotIndex}{config.FileNameSeparator}{config.FileNameTemp}",
            validator : fileValidator,
            isCompressionEnabled : false,
            isPrettyPrint : config.IsPrettyPrint
        );

        HasSaveData = false;
    }

    public bool TryWriteSaveData(SaveData saveData) 
    {
        if (!PersistenceValidator.IsValidSaveData(saveData)) return false;
        WriteSaveData(saveData);
        return true;
    }

    private void WriteSaveData(SaveData saveData) 
    {
        tempWriter.WriteAllJson(saveData);
        // create emergency from previous save data
        if (config.IsSaveFileCompressionEnabled)
            IOUtils.Copy(defaultWriter.PathCompressed, emergencyWriter.PathCompressed);
        else 
            IOUtils.Copy(defaultWriter.PathUncompressed, emergencyWriter.PathUncompressed);
        // replace default save with temp
        IOUtils.Copy(tempWriter.PathUncompressed, defaultWriter.PathUncompressed);
        IOUtils.Delete(tempWriter.PathUncompressed);

        if (!config.IsSaveFileCompressionEnabled) return;
        defaultWriter.Compress();
        emergencyWriter.Compress();
    }

    private bool TryReadSaveDataAtPath(FileWriterJson writer, out SaveData saveData) 
    {
        saveData = writer.ReadAllJson<SaveData>() as SaveData;
        return saveData != null;
    }

    //public bool HasSaveData() => File.Exists(defaultWriter.PathUncompressed) || File.Exists(emergencyWriter.PathUncompressed);
    public bool TryGetLastSaveData(out SaveData saveData, bool needsValidation = true)
    {
        saveData = null;
        HasSaveData = false;

        if(config.IsSaveFileCompressionEnabled) 
        {
            defaultWriter.Decompress();
            emergencyWriter.Decompress();
        }

        if (!TryReadSaveDataAtPath(defaultWriter, out saveData))
            if (!TryReadSaveDataAtPath(emergencyWriter, out saveData)) 
                return false;

        if(config.IsSaveFileCompressionEnabled) 
        {
            IOUtils.Delete(defaultWriter.PathUncompressed);
            IOUtils.Delete(emergencyWriter.PathUncompressed);
        }

        if (needsValidation && (saveData == null || !PersistenceValidator.IsValidSaveData(saveData))) return false;
        HasSaveData = true;
        return true;
    }
}
