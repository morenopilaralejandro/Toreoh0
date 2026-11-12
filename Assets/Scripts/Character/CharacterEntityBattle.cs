using UnityEngine;

public class CharacterEntityBattle : CharacterEntity
{
    public CharacterComponentControllerTouchBattle CharacterComponentControllerTouchBattle;
    public CharacterComponentTarget CharacterComponentTarget;
    public CharacterIndicatorBattleSide CharacterIndicatorBattleSide;

    public void InitializeForBattle(Character character)
    {
        Initialize(character);
        CharacterComponentControllerTouchBattle.Initialize(this);
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
}
