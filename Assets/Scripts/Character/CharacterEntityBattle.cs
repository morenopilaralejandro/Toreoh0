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

    public void InitializeForBattle(Character character)
    {
        Initialize(character);

        CharacterComponentControllerTouchBattle.Initialize();
        CharacterComponentAI.Initialize(this);

        CharacterComponentTarget = new CharacterComponentTarget(this);
        CharacterComponentAIBehaviour = new CharacterComponentAIBehaviour(this);
        CharacterComponentCharge = new CharacterComponentCharge(this);

        this.Character.CharacterComponentFatigue.Subscribe();
        this.CharacterComponentAIBehaviour.Subscribe();
        this.CharacterComponentAI.Subscribe();
    }

    private void OnDisable() 
    {
        this.Character.CharacterComponentFatigue.Unsubscribe();
        this.CharacterComponentAIBehaviour.Unsubscribe();
        this.CharacterComponentAI.Unsubscribe();
    }

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

    public void SetControllerEnable(bool isEnable) 
    {
        CharacterComponentControllerTouchBattle.enabled = isEnable;
        CharacterComponentControllerTouchBattle.SetIsControlled(isEnable);

        CharacterComponentAI.enabled = !isEnable;
        CharacterComponentAI.SetIsAiEnabled(!isEnable);
    }

    public bool CanAct => !CharacterComponentStateLock.IsStateLocked;
    public bool CanMove => !CharacterComponentStateLock.IsStateLocked;
}
