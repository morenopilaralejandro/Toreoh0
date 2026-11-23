public static class BulletPatternFactory
{
    public static BulletPattern Create(BulletPatternData data) => new BulletPattern(data);
    public static BulletPattern CreateById(string id) => Create(DatabaseManager.Instance.DatabaseRegistry.BulletPatternData.Get(id));
    public static BulletPattern CreateByMapping(BulletPatternMapping mapping) => new BulletPattern(DatabaseManager.Instance.DatabaseRegistry.BulletPatternData.Get(mapping.BulletPatternId), mapping.DamageBase);
}
