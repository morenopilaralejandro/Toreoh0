using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneSetupGroupManager : EditorWindow
{
    private SceneSetupGroupData data;

    [MenuItem("Tools/SceneSetup/SceneSetupGroupManager")]
    public static void ShowWindow()
    {
        GetWindow<SceneSetupGroupManager>("SceneSetupGroupManager");
    }

    public void OnGUI() 
    {
        GUILayout.Label("SceneSetupGroupManager", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        data = (SceneSetupGroupData)EditorGUILayout.ObjectField(
            "SceneSetupGroupData",
            data,
            typeof(SceneSetupGroupData),
            false        
        );
        EditorGUILayout.Space();
        if(GUILayout.Button("Load", GUILayout.Height(40)))
        {
            if(data != null) Load();
        }
        EditorGUILayout.Space();
        if(GUILayout.Button("Save", GUILayout.Height(40)))
        {
            if(data != null) Save();
        }
    }

    private void Save() 
    {
        data.SceneSetupArray = EditorSceneManager.GetSceneManagerSetup();
    }

    private void Load() 
    {
        EditorSceneManager.RestoreSceneManagerSetup(data.SceneSetupArray);
    }
}
