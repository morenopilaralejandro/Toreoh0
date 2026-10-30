public static class ArmorFactory
{
    public static Armor Create(ArmorData data) => new Armor(data);
    public static Armor CreateById(string id) => Create(DatabaseManager.Instance.DatabaseRegistry.ArmorData.Get(id));
}
