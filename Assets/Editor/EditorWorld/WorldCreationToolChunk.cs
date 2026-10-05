using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class WorldCreationToolChunk : WorldCreationTool<SceneRootChunk>
{
    private OverworldData overworldData;
    private ZoneData zoneData;
    private Vector2Int chunkCoord;
    
    [MenuItem("Tools/World/WorldCreationToolChunk")]
    public static void ShowWindow()
    {
        GetWindow<WorldCreationToolChunk>("WorldCreationToolChunk");
    }

    public void OnGUI() 
    {
        GUILayout.Label("WorldCreationToolChunk", EditorStyles.boldLabel);
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
        chunkCoord = EditorGUILayout.Vector2IntField("chunkCoord", chunkCoord);

        if (zoneData != null)
            overworldData = zoneData.OverworldData;

        EditorGUILayout.Space();

        if (overworldData == null) return;
        if (IsExistingChunk(chunkCoord))
            EditorGUILayout.HelpBox("Chunk already exists", MessageType.Warning);
        GUILayout.Label("Neighbors:", EditorStyles.miniLabel);
        LayoutNeighborStatus(Vector2Int.up, "up");
        LayoutNeighborStatus(Vector2Int.down, "down");
        LayoutNeighborStatus(Vector2Int.left, "left");
        LayoutNeighborStatus(Vector2Int.right, "right");

        EditorGUILayout.Space();

        bool isValid = config != null && zoneData != null && gridPrefab != null;
        if(GUILayout.Button("Create"))
        {
            if(isValid) CreateScene();
        }
    }

    private bool IsExistingChunk(Vector2Int coord) 
    {
        return overworldData.Chunks.Exists(c => c.ChunkCoord == coord);
    }

    private void LayoutNeighborStatus(Vector2Int direction, string label) 
    {
        Vector2Int coord = chunkCoord + direction;
        string status = IsExistingChunk(coord) ? "exists" : "empty";
        EditorGUILayout.LabelField($"{label} ({coord.x}, {coord.y}) -> status");
    }

    protected override void CreateScene() 
    {
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);

        string id = $"{config.PrefixChunk}_{overworldData.OverworldId}_{chunkCoord.x}_{chunkCoord.y}";
        string sceneAddress = id;
        string scenePath = $"{config.SceneZoneFolder}/{sceneAddress}.unity";

        ChunkData chunkData = new ChunkData
        {
            ChunkId = id,
            ZoneData = zoneData,
            ChunkCoord = chunkCoord,
            SceneAddressChunk = sceneAddress
        };
        overworldData.Chunks.Add(chunkData);
        
        var sceneRoot = base.CreateSceneRoot();
        sceneRoot.ChunkData = chunkData;

        base.CreateGrid(scene);
        base.CreateEmptyObjectAll();
        base.SetSnappableTransforms(sceneRoot);
        base.FinalizeScene(scene, scenePath, overworldData);
    }
}
