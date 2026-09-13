using Aremoreno.Enums.Log;
using System.Diagnostics;

public static class CustomLog 
{
    private static LogLevel minimunLogLevel = LogLevel.Trace;

    public static void SetMinimunLogLevel(LogLevel logLevel) => minimunLogLevel = logLevel;

    public static void Log(string message, LogLevel logLevel, UnityEngine.Object context = null) 
    {
        if(logLevel < minimunLogLevel) return;
        switch(logLevel) 
        {
            case LogLevel.Warning:
                UnityEngine.Debug.LogWarning(message, context);
                break;
            case LogLevel.Error:
            case LogLevel.Fatal:
                UnityEngine.Debug.LogError(message, context);
                break;
            default:
                UnityEngine.Debug.Log(message, context);
                break;
        }
    }

    [Conditional("UNITY_EDITOR")]
    [Conditional("DEVELOPMENT_BUILD")]
    public static void Trace(string message, UnityEngine.Object context = null) => Log(message, LogLevel.Trace, context);

    [Conditional("UNITY_EDITOR")]
    [Conditional("DEVELOPMENT_BUILD")]
    public static void Debug(string message, UnityEngine.Object context = null) => Log(message, LogLevel.Debug, context);

    [Conditional("UNITY_EDITOR")]
    [Conditional("DEVELOPMENT_BUILD")]
    public static void Info(string message, UnityEngine.Object context = null) => Log(message, LogLevel.Info, context);

    public static void Warning(string message, UnityEngine.Object context = null) => Log(message, LogLevel.Warning, context);
    public static void Error(string message, UnityEngine.Object context = null) => Log(message, LogLevel.Error, context);
    public static void Fatal(string message, UnityEngine.Object context = null) => Log(message, LogLevel.Fatal, context);
}
