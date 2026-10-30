using Aremoreno.Enums.Battle;

public class TeamComponentAttributes
{
    public string TeamId;
    public string TeamGuid;

    public TeamComponentAttributes(TeamData data) 
    {
        TeamId = data.TeamId;
        TeamGuid = data.TeamId;
    }
}
