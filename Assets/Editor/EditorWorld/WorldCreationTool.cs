using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;

public abstract class WorldCreationTool<T> : EditorWindow where T : SceneRoot
{
    protected WorldConfig config;
    protected GameObject gridPrefab;
    protected Transform rootTransform;
    protected List<Transform> listSnappableTransforms;

    protected abstract void CreateScene();

    protected T CreateSceneRoot()
    {
        GameObject root = new GameObject("Root");
        rootTransform = root.transform;
        return root.AddComponent<T>();
    }

    protected void CreateGrid(Scene scene)
    {
        GameObject grid = (GameObject)PrefabUtility.InstantiatePrefab(gridPrefab, scene);
        grid.transform.SetParent(rootTransform);
    }

    protected void CreateEmptyObjectAll() 
    {
        listSnappableTransforms = new ();
        foreach (string obj in config.SceneEmptyObjects)
            CreateEmptyObject(obj, rootTransform);
    }

    protected void CreateEmptyObject(string name, Transform parentTransform) 
    {
        GameObject go = new GameObject(name);
        go.transform.SetParent(parentTransform);
        listSnappableTransforms.Add(go.transform);
    }

    protected void SetSnappableTransforms(T sceneRoot) 
    {
        sceneRoot.ListSnappableTransforms = listSnappableTransforms;
    }

    protected void FinalizeScene(Scene scene, string scenePath, Object modifiedObject) 
    {
        EditorSceneManager.SaveScene(scene, scenePath);
        EditorUtils.AssignAssetToAddressableGroup(
            EditorUtils.GetAssetGuid(scenePath),
            EditorUtils.GetAddressableGroupByGuid(config.AddressableGroup)
        );
        EditorSceneManager.CloseScene(scene, true);
        EditorUtils.SetDirty(modifiedObject);
        EditorUtils.SaveAssets();
        EditorUtils.RefreshAssets();
    }
}
