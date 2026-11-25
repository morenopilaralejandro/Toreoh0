using UnityEngine;

public class BattleComponentPause
{
    private Battle battle;
    private BattleConfig battleConfig;

    public bool IsPausedPhysic;
    public bool IsPausedBattle;

    public BattleComponentPause(Battle battle, BattleConfig battleConfig)
    {
        this.battle = battle;
        this.battleConfig = battleConfig;
    }

    public void Pause() 
    {
        PausePhysic();
        PauseBattle();
    }

    public void Resume() 
    {
        ResumePhysic();
        ResumeBattle();
    }

    public void PausePhysic() 
    {
        IsPausedPhysic = true;
        Time.timeScale =  battleConfig.TimeScaleFrozen;
    }

    public void ResumePhysic() 
    {
        Time.timeScale =  battleConfig.TimeScaleDefault;
        IsPausedPhysic = false;
    }

    public void PauseBattle() 
    {
        IsPausedBattle = true;
    }

    public void ResumeBattle() 
    {
        IsPausedBattle = false;
    }
}
