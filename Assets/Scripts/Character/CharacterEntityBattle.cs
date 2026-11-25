using UnityEngine;

public class CharacterEntityBattle : CharacterEntity
{
    public CharacterComponentControllerTouchBattle CharacterComponentControllerTouchBattle;
    public CharacterComponentTarget CharacterComponentTarget;
    public CharacterIndicatorBattleSide CharacterIndicatorBattleSide;
    public CharacterComponentStateLock CharacterComponentStateLock;
    public CharacterComponentAIBehaviour CharacterComponentAIBehaviour;
    public CharacterComponentAI CharacterComponentAI;
    public CharacterComponentCharge CharacterComponentCharge;
    public CharacterComponentStatusEffectBattle CharacterComponentStatusEffectBattle;
    public CharacterComponentAIDecisionMove CharacterComponentAIDecisionMove; 

    // lifecycle
    public void InitializeForBattle(Character character)
    {
        Initialize(character);

        CharacterComponentControllerTouchBattle.Initialize();

        CharacterComponentTarget = new CharacterComponentTarget(this);
        CharacterComponentAIBehaviour = new CharacterComponentAIBehaviour(this);
        CharacterComponentAI = new CharacterComponentAI(this);
        CharacterComponentCharge = new CharacterComponentCharge(this);
        CharacterComponentAIDecisionMove = new CharacterComponentAIDecisionMove(this);

        this.Character.CharacterComponentFatigue.Subscribe();
        this.CharacterComponentAIBehaviour.Subscribe();
        this.CharacterComponentAI.Subscribe();
        this.CharacterComponentStatusEffectBattle.Subscribe();
    }

    private void OnDisable() 
    {
        this.Character.CharacterComponentFatigue.Unsubscribe();
        this.CharacterComponentAIBehaviour.Unsubscribe();
        this.CharacterComponentAI.Unsubscribe();
        this.CharacterComponentStatusEffectBattle.Unsubscribe();
    }

    // event

    // update
    private void FixedUpdate()
    {
        if (CharacterComponentControllerTouchBattle.IsControlled) 
        {
            CharacterComponentControllerTouchBattle.FixedUpdateInternal();
            CharacterComponentCharge.FixedUpdateInternal();
        }

        if (CharacterComponentAI.IsAiEnabled)
            CharacterComponentAI.FixedUpdateInternal();
    }

    private void LateUpdate()
    {
        if (CharacterComponentControllerTouchBattle.IsControlled)
            CharacterComponentControllerTouchBattle.LateUpdateInternal();
    }

    // api
    public void SetControllerEnable(bool isEnable) 
    {
        CharacterComponentControllerTouchBattle.enabled = isEnable;
        CharacterComponentControllerTouchBattle.SetIsControlled(isEnable);

        // CharacterComponentAI.enabled = !isEnable;
        CharacterComponentAI.SetIsAiEnabled(!isEnable);
    }

    public bool CanAct =>  !CharacterComponentStateLock.IsStateLocked && !Character.CharacterComponentStatusEffectVolatile.IsStunned && !Character.CharacterComponentStatusEffectPermanent.IsFainted;
    public bool CanMove => !CharacterComponentStateLock.IsStateLocked && !Character.CharacterComponentStatusEffectVolatile.IsStunned && !Character.CharacterComponentStatusEffectPermanent.IsFainted;
}
