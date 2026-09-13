using UnityEngine;
using Aremoreno.Enums.Log;

[CreateAssetMenu(fileName = "DebugConfig", menuName = "ScriptableObject/Debug/DebugConfig")]
public class DebugConfig : ScriptableObject
{
    [Header("Scene")]
    public bool IsBootToDebugMainMenu;

    [Header("Log")]
    public LogLevel MinimunLogLevel;
}
