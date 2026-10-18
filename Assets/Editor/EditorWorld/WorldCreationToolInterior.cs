using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class WorldCreationToolInterior : WorldCreationTool<SceneRootInterior>
{
    private ZoneData zoneData;
    
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
        gridPrefab = (GameObject)EditorGUILayout.ObjectField(
            "gridPrefab",
            gridPrefab,
            typeof(GameObject),
            false        
        );
        zoneData = (ZoneData)EditorGUILayout.ObjectField(
            "zoneData",
            zoneData,
            typeof(ZoneData),
            false        
        );
        EditorGUILayout.Space();

        bool isValid = config != null && zoneData != null && gridPrefab != null;
        if(GUILayout.Button("Create"))
        {
            if(isValid) CreateScene();
        }
    }

    protected override void CreateScene() 
    {
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);

        string sceneAddress = $"{config.PrefixInterior}_{zoneData.ZoneId}";
        string scenePath = $"{config.SceneZoneFolder}/{sceneAddress}.unity";

        zoneData.SceneAddressInterior = sceneAddress;
        
        var sceneRoot = CreateSceneRoot();
        sceneRoot.ZoneData = zoneData;

        base.CreateGrid(scene);
        base.CreateEmptyObjectAll();
        base.SetSnappableTransforms(sceneRoot);
        base.FinalizeScene(scene, scenePath, zoneData);
    }
}
