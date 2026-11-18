public abstract class WinCondition : IWinCondition
{
    protected Battle battle;

    public virtual void Initialize(Battle battle) 
    {
        this.battle = battle;
    }

    public abstract bool CheckCondition();
}
