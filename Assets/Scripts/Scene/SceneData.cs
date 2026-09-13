using UnityEngine;

[CreateAssetMenu(fileName = "SceneData", menuName = "ScriptableObject/Scene/SceneData")]
public class SceneData : ScriptableObject
{
    public string SceneName;
    public bool IsDebugOnly;
    public bool HasLoadingScreen;
}
