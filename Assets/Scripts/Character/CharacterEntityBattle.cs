using UnityEngine;

public class CharacterEntityBattle : CharacterEntity
{
    public CharacterComponentControllerTouchBattle CharacterComponentControllerTouchBattle;
    public CharacterComponentTarget CharacterComponentTarget;
    public CharacterIndicatorBattleSide CharacterIndicatorBattleSide;
    public CharacterComponentStateLock CharacterComponentStateLock;

    public void InitializeForBattle(Character character)
    {
        Initialize(character);
        CharacterComponentControllerTouchBattle.Initialize();
        CharacterComponentTarget = new CharacterComponentTarget(this);
    }

    private void FixedUpdate()
    {
        if (CharacterComponentControllerTouchBattle.IsControlled)
            CharacterComponentControllerTouchBattle.FixedUpdateInternal();
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
    }

    public bool CanAct => !CharacterComponentStateLock.IsStateLocked;
    public bool CanMove => !CharacterComponentStateLock.IsStateLocked;
}
