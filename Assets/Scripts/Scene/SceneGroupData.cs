using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SceneGroupData", menuName = "ScriptableObject/Scene/SceneGroupData")]
public class SceneGroupData : ScriptableObject
{
    public string SceneGroupId;
    public bool HasLoadingScreen = true;
    public List<SceneData> Scenes = new ();

    private List<string> validScenes;

    public IReadOnlyList<string> GetValidScenes() 
    {
        if (validScenes != null) return validScenes;
        validScenes = new List<string>(Scenes.Count);
        foreach(SceneData scene in Scenes) 
        {
            if(!scene.IsDebugOnly || DebugUtils.IsDevBuild)
                validScenes.Add(scene.SceneName);
        }
        return validScenes;
    }
}
