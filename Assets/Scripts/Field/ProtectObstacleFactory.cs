public static class ProtectObstacleFactory
{
    public static ProtectObstacle Create(ProtectObstacleData data) => new ProtectObstacle(data);
    public static ProtectObstacle CreateById(string id) => Create(DatabaseManager.Instance.DatabaseRegistry.ProtectObstacleData.Get(id));
}
