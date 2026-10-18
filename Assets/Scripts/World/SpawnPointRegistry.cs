using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ChunkData", menuName = "ScriptableObject/World/SpawnPointRegistry")]
public class SpawnPointRegistry : ScriptableObject
{
    [SerializeField] private List<SpawnPoint> listSpawnPoint = new ();
    private Dictionary<string, SpawnPoint> dictSpawnPoint = new ();

    public void Initialize() 
    {
        BuildDict();
    }

    public void Register(ZoneData zoneData)
    {
        foreach(var spawnPoint in zoneData.SpawnPoints) 
        {
            spawnPoint.ZoneId = zoneData.ZoneId;
            listSpawnPoint.Add(spawnPoint);
        }
    }

    private void BuildDict() 
    {
        foreach(var point in listSpawnPoint) 
            dictSpawnPoint[point.SpawnPointId] = point;
    }

    public bool TryGet(string id, out SpawnPoint point) 
    {
        if (dictSpawnPoint.TryGetValue(id, out point))
            return true;
        else
            return false;
    }

    public SpawnPoint Get(string id) => dictSpawnPoint[id];
    public void Clear() => dictSpawnPoint.Clear();

}
