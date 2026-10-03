[CreateAssetMenu(fileName = "OverworldData", menuName = "ScriptableObject/World/OverworldData")]
public class OverworldData : ScriptableObject
{
    public string OverworldId;
    public List<ChunkData> Chunks;
    // public List<ZoneData> Zones;
}
