using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public abstract class WorldCreationTool : EditorWindow
{
    protected gridPrefab

    private void CreateScene() 
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

        // root
        GameObject root = new GameObject("Root");
        var sceneRoot = root.AddComponent<SceneRootChunk>();
        sceneRoot.ChunkData = chunkData;

        // grid
        GameObject grid = (GameObject)PrefabUtility.InstantiatePrefab(gridPrefab, scene);
        grid.transform.SetParent(root.transform);

        foreach (string obj in config.SceneEmptyObjects)
            base.CreateEmptyObject(obj, root.transform);

    }

    CreateRoot T   pass the T and also return the object 
    {
        GameObject root = new GameObject("Root");
        var sceneRoot = root.AddComponent<SceneRootChunk>();
        sceneRoot.ChunkData = chunkData;

        // the part of new go is for the tranform
        // the part of add component is for setting data
    }

    CreateGrid 
    {
        GameObject grid = (GameObject)PrefabUtility.InstantiatePrefab(gridPrefab, scene);
        grid.transform.SetParent(root.transform);
    }

    private void CreateEmptyObject(string name, Transform parentTransform) 
    {
        GameObject go = new GameObject(name);
        go.transform.SetParent(parentTransform);
    }

    private void FinalizeScene(Scene scene, string scenePath, Object modifiedObject) 
    {
        EditorSceneManager.SaveScene(scene, scenePath);
        EditorSceneManager.CloseScene(scene, true);
        EditorUtils.SetDirty(modifiedObject);
        EditorUtils.SaveAssets();
        EditorUtils.RefreshAssets();
    }
}
