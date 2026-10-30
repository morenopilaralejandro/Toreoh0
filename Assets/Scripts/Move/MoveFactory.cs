public static class MoveFactory
{
    public static Move Create(MoveData data) => new Move(data);
    public static Move CreateById(string id) => Create(DatabaseManager.Instance.DatabaseRegistry.MoveData.Get(id));
}
