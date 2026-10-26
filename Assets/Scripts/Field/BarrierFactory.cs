public static class BarrierFactory
{
    public static Barrier Create(BarrierData data) => new Barrier(data);
    public static Barrier CreateById(string id) => Create(DatabaseManager.Instance.DatabaseRegistry.BarrierData.Get(id));
}
