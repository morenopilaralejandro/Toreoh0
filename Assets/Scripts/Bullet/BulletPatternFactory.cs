public static class BulletPatternFactory
{
    public static BulletPattern Create(BulletPatternData data) => new BulletPattern(data);
    public static BulletPattern CreateById(string id) => Create(DatabaseManager.Instance.DatabaseRegistry.BulletPatternData.Get(id));
}
