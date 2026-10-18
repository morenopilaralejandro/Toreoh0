public static class ChestFactory
{
    public static Chest Create(ChestData data) => new Chest(data);
    public static Chest CreateById(string id) => Create(DatabaseManager.Instance.DatabaseRegistry.ChestData.Get(id));
}
