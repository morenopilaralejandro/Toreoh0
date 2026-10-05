using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public abstract class SceneRoot : MonoBehaviour
{
    [SerializeField] protected List<SpawnPoint> spawnPoints = new();
    public List<Transform> ListSnappableTransforms;
    protected SpawnPointRegistry spawnPointRegistry;

    protected abstract Vector3 size { get; }
    protected abstract Vector3 center { get; }
    protected Color fillColorFillDefault = 
        ColorUtils.ChangeAlpha(
            WorldConstants.GizmosColorSceneRootDefaultFill,
            WorldConstants.GizmosAlphaSceneRootFill
        );
    protected Color fillColorFillSelected = 
        ColorUtils.ChangeAlpha(
            WorldConstants.GizmosColorSceneRootSelectedFill,
            WorldConstants.GizmosAlphaSceneRootFill
        );


    // lifecycle
    protected void Start() 
    {
        spawnPointRegistry = WorldManager.Instance.SpawnPointRegistry;
        spawnPointRegistry.Register(spawnPoints);
    }

    protected void OnDestroy() 
    {
        if (spawnPointRegistry != null)
            spawnPointRegistry.Unregister(spawnPoints);
    }

    // spawn
    [ContextMenu("CollectSpawnPoints")]
    protected virtual void CollectSpawnPoints()
    {
        GetComponentsInChildren<SpawnPoint>(spawnPoints);
        EditorUtility.SetDirty(this);
    }

    // snap
    [ContextMenu("SnapTransforms")]
    protected void SnapTransforms()
    {
        foreach (Transform transformParent in ListSnappableTransforms)
            foreach(Transform transformChild in transformParent) 
                SnapTransform(transformChild);
    }

    protected void SnapTransform(Transform transform)
    {
        Vector3 pos = transform.position;
        Vector3 newPos = new Vector3(
            SnapValue(pos.x),
            SnapValue(pos.y),
            pos.z
        );
        transform.position = newPos;
    }

    protected float SnapValue(float floatValue) => Mathf.Floor(floatValue * 10f) / 10f;

    // gizmos
    protected void OnDrawGizmos()
    {
        GizmosUtils.DrawCube(
            fillColorFillDefault,
            center,
            size,
            isSolid: true
        );

        GizmosUtils.DrawCube(
            WorldConstants.GizmosColorSceneRootDefaultOutline,
            center,
            size,
            isSolid: false
        );
    }

    protected void OnDrawGizmosSelected()
    {

        GizmosUtils.DrawCube(
            WorldConstants.GizmosColorSceneRootSelectedOutline,
            center,
            size,
            isSolid: false
        );

        /*
        protected override float sizeFloat => WorldConstants.CHUCK_SIZE;
        protected override float sizeFloat => WorldConstants.INTERIOR_SIZE;

        Bounds bounds = new Bounds(center, size);
        for (int i = 1, i < sizeFloat; i++) 
        {
            GizmosUtils.DrawLine(
                WorldConstants.GizmosColorSceneRootSelectedLine,
                bounds.min + new Vector3(i, 0f, 0f),
                bounds.min + new Vector3(i, sizeFloat, 0f)
            );

            GizmosUtils.DrawLine(
                WorldConstants.GizmosColorSceneRootSelectedLine,
                bounds.min + new Vector3(0f, i, 0f),
                bounds.min + new Vector3(sizeFloat, i, 0f)
            );
        }
        */
    }
}
