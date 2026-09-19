using Aremoreno.Enums.Log;

public class FileLogger 
{
    private DebugConfig config;
    private FileWriter fileWriter;
    
    public void Initialize(DebugConfig config) 
    {
        this.config = config;
        fileWriter = new FileWriter();
        fileWriter.Initialize(config.FileLoggerPath);
    }

    public void WriteToFile(string message, LogLevel logLevel) 
    {
        if(!ShouldLogToFile(logLevel)) return;
        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        fileWriter.WriteToFile($"[{timestamp}] {message}");    
    }

    private bool ShouldLogToFile(LogLevel logLevel) 
    {
        #if UNITY_EDITOR || DEVELOPMENT_BUILD
            return config.IsFileLoggerEnable;
        #else
            return config.IsFileLoggerEnable && 
            (logLevel == LogLevel.Error || logLevel == LogLevel.Fatal);
        #endif
    }

    public void Disable() 
    {
        fileWriter.Disable();
    }
}
