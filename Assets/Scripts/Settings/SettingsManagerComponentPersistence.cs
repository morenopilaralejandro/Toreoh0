public class SettingsManagerComponentPersistence
{
    private SettingsManager manager;
    private SettingsConfig config;
    private FileWriterJson writer;


    public SettingsManagerComponentPersistence(SettingsManager manager, SettingsConfig config)
    {
        this.manager = manager;
        this.config = config;

        writer = new FileWriterJson(
            pathFolder : IOUtils.PathCombinePersistent(config.Folder),
            pathFileName : config.FileName,
            validator : new FileValidatorBasic(),
            isCompressionEnabled : config.IsCompressionEnabled,
            isPrettyPrint : config.IsPrettyPrint
        );
    }

    public void Export()
    {
        writer.Write(manager.Settings);
    }

    public void Import()
    {
        if (IOUtils.IsExistingFile(writer.PathUncompressed)) 
            manager.Settings = writer.Read<Settings>();
        else
            manager.Settings = config.PresetDefault;
        SettingsEvents.RaiseSettingsLoadEnded(manager.Settings);
    }

    public void Overwrite(Settings settings)
    {
        manager.Settings = settings;
        SettingsEvents.RaiseSettingsLoadEnded(settings);
    }
}
