using UnityEngine;
using UnityEditor;

public class SceneRootInterior : SceneRoot
{
    public ZoneData ZoneData;

    protected override Vector3 size => 
        new Vector3(
            WorldConstants.INTERIOR_SIZE,
            WorldConstants.INTERIOR_SIZE,
            1f
        );

    protected override Vector3 center => 
        new Vector3(
            WorldConstants.TILE_OFFSET * WorldConstants.INTERIOR_SIZE,
            WorldConstants.TILE_OFFSET * WorldConstants.INTERIOR_SIZE,
            0f
        );

    // spawn
    [ContextMenu("CollectSpawnPoints")]
    protected override void CollectSpawnPoints() 
    {
        base.CollectSpawnPoints();
        ZoneData.SpawnPoints.Clear();
        foreach (var spawnPoint in base.spawnPoints)
            ZoneData.SpawnPoints.Add(spawnPoint);
        EditorUtility.SetDirty(ZoneData);
    }
}
