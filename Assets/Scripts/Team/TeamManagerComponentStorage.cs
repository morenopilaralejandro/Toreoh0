using System.Collections.Generic;

public class TeamManagerComponentStorage
{
    //fields
    public List<Team> ListTeam = new();
    private TeamConfig config;

    // constructor
    public TeamManagerComponentStorage(TeamConfig config)
    {
        this.config = config;
    }

    // add
    public void Add(Team Team)
    {

    }

    // remove
    public void Remove(Team Team) 
    {

    }

    // query

    // persistence
    public void Clear()
    {
        ListTeam.Clear();
    }

    public void InitializeForNewGame()
    {
        Clear();
        // Add default team
    }

    public TeamManagerComponentStorageSaveData Export() 
    {
        TeamManagerComponentStorageSaveData saveData = new();
        saveData.ListTeamSaveData = new ();
        foreach (var team in ListTeam)
            saveData.ListTeamSaveData.Add(team.TeamComponentPersistence.Export());
        return saveData;
    }

    public void Import(TeamManagerComponentStorageSaveData saveData) 
    {
        Clear();
        // import saveData
    }
}
