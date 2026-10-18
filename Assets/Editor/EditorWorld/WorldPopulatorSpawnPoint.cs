using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class WorldPopulatorSpawnPoint : EditorWindow
{
    private SpawnPointRegistry registry;

    [MenuItem("Tools/World/WorldPopulatorSpawnPoint")]
    public static void ShowWindow()
    {
        GetWindow<WorldPopulatorSpawnPoint>("WorldPopulatorSpawnPoint");
    }

    public void OnGUI() 
    {
        GUILayout.Label("WorldPopulatorSpawnPoint", EditorStyles.boldLabel);
        registry = (SpawnPointRegistry)EditorGUILayout.ObjectField(
            "registry",
            registry,
            typeof(SpawnPointRegistry),
            false        
        );
        if(GUILayout.Button("Populate"))
        {
            if(registry != null) Populate();
        }
    }

    private void Populate()
    {
        List<ZoneData> zoneList = new ();
        string[] zoneGuids = EditorUtils.FindAssets("t:ZoneData");
        registry.Clear();
        foreach (string guid in zoneGuids) 
            zoneList.Add(EditorUtils.LoadAssetAtPath<ZoneData>(EditorUtils.GetAssetPath(guid)));
        foreach (ZoneData zoneData in zoneList)
            registry.Register(zoneData);
        EditorUtils.SetDirty(registry);
    }
}
