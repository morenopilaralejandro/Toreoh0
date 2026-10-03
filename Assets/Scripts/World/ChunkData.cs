using UnityEngine;

[CreateAssetMenu(fileName = "ChunkData", menuName = "ScriptableObject/World/ChunkData")]
public class ChunkData : ScriptableObject
{
    public string ChunkId;
    public ZoneData ZoneData;
    public Vector2Int ChunkCoord;
    public string SceneAddressChunk;
    //public List<string> SpawnPointIds = new List<string>();
}
