public class TeamComponentPersistence
{
    private Team team;

    public TeamComponentPersistence(Team team)
    {
        this.team = team;
    }

    public TeamSaveData Export()
    {
        return null;
        /*
        return new TeamSaveData 
        {
            TeamManagerComponentStorageSaveData = TeamManager.StorageComponent.Export(),
            TeamManagerComponentCurrencySaveData = TeamManager.CurrencyComponent.Export()
        };
        */
    }
}
