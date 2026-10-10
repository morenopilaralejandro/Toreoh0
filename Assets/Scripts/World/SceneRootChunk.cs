using UnityEngine;
using UnityEditor;

[ExecuteAlways]
public class SceneRootChunk : SceneRoot
{
    public ChunkData ChunkData;

    protected override Vector3 size => 
        new Vector3(
            WorldConstants.CHUCK_SIZE,
            WorldConstants.CHUCK_SIZE,
            1f
        );

    protected override Vector3 center => 
        new Vector3(
            (ChunkData.ChunkCoord.x + WorldConstants.TILE_OFFSET) * WorldConstants.CHUCK_SIZE,
            (ChunkData.ChunkCoord.y + WorldConstants.TILE_OFFSET) * WorldConstants.CHUCK_SIZE,
            0f
        );

    private void Awake() 
    {
        SnapChunk();
    }

    // spawn
    #if UNITY_EDITOR 
    [ContextMenu("CollectSpawnPoints")]
    protected override void CollectSpawnPoints() 
    {
        base.CollectSpawnPoints();
        foreach (var spawnPoint in base.spawnPoints)
            ChunkData.ZoneData.SpawnPoints.Add(spawnPoint);
        EditorUtility.SetDirty(ChunkData.ZoneData);
        
    }
    #endif

    // snap
    private void SnapChunk() 
    {
        if (ChunkData == null) return;
        Vector3 pos = new Vector3(
            ChunkData.ChunkCoord.x * WorldConstants.CHUCK_SIZE,
            ChunkData.ChunkCoord.y * WorldConstants.CHUCK_SIZE,
            0f
        );
        transform.position = pos;
    }

    // Gizmos
    #if UNITY_EDITOR 
    protected override void OnDrawGizmos() 
    {
        base.OnDrawGizmos();
        UnityEditor.Handles.Label(
            center - (size / 2.20f),
            ChunkData.ChunkId
        );
    }
    #endif
}
