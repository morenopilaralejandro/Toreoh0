public static class FormationCoordFactory
{
    public static FormationCoord Create(FormationCoordData data) => new FormationCoord(data);
    public static FormationCoord CreateById(string id) => Create(DatabaseManager.Instance.DatabaseRegistry.FormationCoordData.Get(id));
}
