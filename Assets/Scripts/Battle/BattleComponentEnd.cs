using Aremoreno.Enums.Battle;

public class BattleComponentEnd
{
    private Battle battle;
    private bool isEndPending;
    public bool IsForcedWin;
    public bool IsForcedLose;

    public BattleComponentEnd(Battle battle)
    {
        this.battle = battle;
    }

    private void EndInternal() 
    {
        BattleArgs.SetForResults(battle);
        SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-BattleResult");
    }

    public void EndByCondition()
    {
        if (!IsValid()) return;
        battle.BattleComponentMessage.PlayMessage(BattleMessage.Finish);
    }

    public void EndByForfeit()
    {
        if (!IsValid()) return;
        IsForcedLose = true;
        EndInternal();
    }

    private bool IsValid() 
    {
        if (isEndPending) 
        {
            return false;
        } else 
        {
            isEndPending = true;
            return true;
        }
    }

    // Event
    public void Subscribe()
    {
        UIEvents.OnBattleMessageEnded += OnBattleMessageEnded;
    }

    public void Unsubscribe()
    {
        UIEvents.OnBattleMessageEnded -= OnBattleMessageEnded;
    }

    private void OnBattleMessageEnded() 
    {
        if(isEndPending) EndInternal();
    }
}
