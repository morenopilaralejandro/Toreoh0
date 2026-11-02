public abstract class WinCondition : IWinCondition
{
    protected Battle battle;

    public void Initialize(Battle battle) 
    {
        this.battle = battle;
    }

    public abstract bool CheckCondition();
}
