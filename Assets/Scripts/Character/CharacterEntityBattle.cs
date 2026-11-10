using UnityEngine;

public class CharacterEntityBattle : CharacterEntity
{
    public CharacterComponentControllerTouchBattle CharacterComponentControllerTouchBattle;
    public CharacterComponentTarget CharacterComponentTarget;

    public void InitializeForBattle(Character character)
    {
        Initialize(character);
        CharacterComponentControllerTouchBattle.Initialize(this);
        CharacterComponentTarget = new CharacterComponentTarget(this);
    }

    private void FixedUpdate()
    {
        if (CharacterComponentControllerTouchBattle.enabled)
            CharacterComponentControllerTouchBattle.FixedUpdateInternal();
    }

    private void LateUpdate()
    {
        if (CharacterComponentControllerTouchBattle.enabled)
            CharacterComponentControllerTouchBattle.LateUpdateInternal();
    }

    public void SetControllerEnable(bool isEnable) 
    {
        CharacterComponentControllerTouchBattle.enabled = isEnable;
    }
}
