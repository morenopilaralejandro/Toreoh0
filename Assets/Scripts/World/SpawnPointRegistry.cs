public class SpawnPointRegistry 
{
    private List<SpawnPoint> listRegistered = new();

    public void Register(List<SpawnPoint> points) 
    {
        foreach(var point in points) 
            listRegistered.Add(point);
    }

    public void Unregister(List<SpawnPoint> points) 
    {
        foreach(var point in points) 
            listRegistered.Remove(point);
    }

    public SpawnPoint GetSpawnPoint(string spawnPointId) 
    {
        foreach(var point in listRegistered) 
        {
            if (point.SpawnPointId == spawnPointId) return point;
        }
        return null;
    }

    public void Clear() 
    {
        listRegistered.Clear();
    }
}
