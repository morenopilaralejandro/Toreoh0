using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public abstract class SceneRoot : MonoBehaviour
{
    [SerializeField] protected List<SpawnPoint> spawnPoints = new();
    public List<Transform> ListSnappableTransforms;

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

    // spawn
    #if UNITY_EDITOR 
    protected virtual void CollectSpawnPoints()
    {
        List<SpawnPointEntity> listSpawnPointEntity = new ();
        GetComponentsInChildren<SpawnPointEntity>(listSpawnPointEntity);
        spawnPoints.Clear();
        foreach (var entity in listSpawnPointEntity) 
            spawnPoints.Add(entity.GetSpawnPoint());

        EditorUtility.SetDirty(this);
    }
    #endif

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

    protected float SnapValue(float floatValue) => Mathf.Round(floatValue * 2) / 2;

    // gizmos
    protected virtual void OnDrawGizmos()
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

        // draw tiles
        /*
        float sizeFloat = size.x;
        Bounds bounds = new Bounds(center, size);
        for (int i = 1; i < sizeFloat; i++) 
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
