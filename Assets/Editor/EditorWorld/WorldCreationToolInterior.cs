using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class WorldCreationToolInterior : EditorWindow
{
    private WorldConfig config;
    private ZoneData zoneData;
    private GameObject gridPrefab;
    
    [MenuItem("Tools/World/WorldCreationToolInterior")]
    public static void ShowWindow()
    {
        GetWindow<WorldCreationToolInterior>("WorldCreationToolInterior");
    }

    public void OnGUI() 
    {
        GUILayout.Label("WorldCreationToolInterior", EditorStyles.boldLabel);
        config = (WorldConfig)EditorGUILayout.ObjectField(
            "config",
            config,
            typeof(WorldConfig),
            false
        );
        zoneData = (ZoneData)EditorGUILayout.ObjectField(
            "zoneData",
            zoneData,
            typeof(ZoneData),
            false        
        );
        gridPrefab = (GameObject)EditorGUILayout.ObjectField(
            "gridPrefab",
            gridPrefab,
            typeof(GameObject),
            false        
        );

        EditorGUILayout.Space();

        bool isValid = config != null && zoneData != null && gridPrefab != null;
        if(GUILayout.Button("Create"))
        {
            if(isValid) CreateScene();
        }
    }

    private void CreateScene() 
    {
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);

        string sceneAddress = $"{config.PrefixInterior}_{zoneData.ZoneId}";
        string scenePath = $"{config.SceneZoneFolder}/{sceneAddress}.unity";

        zoneData.SceneAddressInterior = sceneAddress;
        
        // root
        GameObject root = new GameObject("Root");
        var sceneRoot = root.AddComponent<SceneRootInterior>();
        sceneRoot.ZoneData = zoneData;

        // grid
        GameObject grid = (GameObject)PrefabUtility.InstantiatePrefab(gridPrefab, scene);
        grid.transform.SetParent(root.transform);

        foreach (string obj in config.SceneEmptyObjects)
            CreateEmptyObject(obj, root.transform);

        EditorSceneManager.SaveScene(scene, scenePath);
        EditorSceneManager.CloseScene(scene, true);

        EditorUtils.SetDirty(zoneData);
        EditorUtils.SaveAssets();
        EditorUtils.RefreshAssets();
    }

    private void CreateEmptyObject(string name, Transform parentTransform) 
    {
        GameObject go = new GameObject(name);
        go.transform.SetParent(parentTransform);
    }
}
