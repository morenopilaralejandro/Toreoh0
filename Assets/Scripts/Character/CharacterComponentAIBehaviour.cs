using System;
using Aremoreno.Enums.Character;
using Aremoreno.Enums.Battle;

public class CharacterComponentAIBehaviour
{
    private CharacterEntityBattle entity;
    public AIBehaviour AIBehaviour;

    public Action<AIBehaviour> OnAIBehaviourChanged;

    public CharacterComponentAIBehaviour(CharacterEntityBattle entity) 
    {
        this.entity = entity;
        SetAIBehaviour(AIBehaviour.Normal);
    }

    public void SetAIBehaviour(AIBehaviour behaviour) 
    {
        AIBehaviour = behaviour;
        OnAIBehaviourChanged?.Invoke(AIBehaviour);
    }

    // event
    public void Subscribe()
    {               
        BattleEvents.OnBattlePhaseChanged += OnBattlePhaseChanged;
    }

    public void Unsubscribe()
    {
        BattleEvents.OnBattlePhaseChanged -= OnBattlePhaseChanged;
    }

    private void OnBattlePhaseChanged(BattlePhase battlePhaseCurrent, BattlePhase battlePhasePrev) 
    {
        if (!entity.CharacterComponentAI.IsAiEnabled) return;
        switch(battlePhaseCurrent) 
        {
            case BattlePhase.Muerte:
                SetAIBehaviour(AIBehaviour.Rage);
                break;
            case BattlePhase.Captura:
                SetAIBehaviour(AIBehaviour.Capture);
                entity.Character.CharacterComponentFatigue.SetFatigueState(FatigueState.Exhausted);
                break;
        }
    }
}
