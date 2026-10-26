public static class FieldFactory
{
    public static Field Create(FieldData data) => new Field(data);
    public static Field CreateById(string id) => Create(DatabaseManager.Instance.DatabaseRegistry.FieldData.Get(id));
}
