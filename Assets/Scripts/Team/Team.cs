public class Team 
{
    public TeamComponentAttributes TeamComponentAttributes;
    public TeamComponentPersistence TeamComponentPersistence;
    public TeamComponentSide TeamComponentSide;

    public Team(TeamData data)
    {
        TeamComponentAttributes = new TeamComponentAttributes(data);
        TeamComponentPersistence = new TeamComponentPersistence(this);
        TeamComponentSide = new TeamComponentSide(data);
    }
}
