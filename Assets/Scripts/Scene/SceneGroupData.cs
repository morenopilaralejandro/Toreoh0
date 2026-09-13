using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SceneGroupData", menuName = "ScriptableObject/Scene/SceneGroupData")]
public class SceneGroupData : ScriptableObject
{
    public string SceneGroupId;
    public bool HasLoadingScreen = true;
    public List<SceneData> Scenes = new ();

    private List<SceneData> validScenes;

    public IReadOnlyList<SceneData> GetValidScenes() 
    {
        if (validScenes != null) return validScenes;
        validScenes = new List<SceneData>(Scenes.Count);
        foreach(SceneData scene in Scenes) 
        {
            if(!scene.IsDebugOnly || DebugUtils.IsDevBuild)
                validScenes.Add(scene);
        }
        return validScenes;
    }
}
