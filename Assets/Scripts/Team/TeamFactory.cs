public static class TeamFactory
{
    public static Team Create(TeamData data) => new Team(data);
    public static Team CreateById(string id) => Create(DatabaseManager.Instance.DatabaseRegistry.TeamData.Get(id));
}
