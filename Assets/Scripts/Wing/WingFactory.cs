public static class WingFactory
{
    public static Wing Create(WingData data) => new Wing(data);
    public static Wing CreateById(string id) => Create(DatabaseManager.Instance.DatabaseRegistry.WingData.Get(id));
}
