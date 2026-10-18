public static class ShopFactory
{
    public static Shop Create(ShopData data) => new Shop(data);
    public static Shop CreateById(string id) => Create(DatabaseManager.Instance.DatabaseRegistry.ShopData.Get(id));
}
