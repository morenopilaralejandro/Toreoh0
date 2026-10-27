public static class FormationFactory
{
    public static Formation Create(FormationData data) => new Formation(data);
    //public static Formation CreateById(string id) => Create(DatabaseManager.Instance.DatabaseRegistry.FormationData.Get(id));
    //public static Formation CreateByHash(string hash) => new Formation(hash);
}
