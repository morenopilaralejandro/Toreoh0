using Aremoreno.Enums.Battle;

public class TeamComponentAttributes
{
    public string TeamId;

    public TeamComponentAttributes(TeamData data) 
    {
        TeamId = data.TeamId;
    }
}
