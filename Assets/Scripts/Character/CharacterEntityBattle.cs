using UnityEngine;

public class CharacterEntityBattle : CharacterEntity
{
    public CharacterComponentControllerTouchBattle CharacterComponentControllerTouchBattle;

    public void InitializeForBattle(Character character)
    {
        Initialize(character);
        CharacterComponentControllerTouchBattle.Initialize(this);
    }

    private void FixedUpdate()
    {
        CharacterComponentControllerTouchBattle.FixedUpdateInternal();
    }

    private void LateUpdate()
    {
        CharacterComponentControllerTouchBattle.LateUpdateInternal();
    }

    public void SetControllerEnable(bool isEnable) 
    {
        CharacterComponentControllerTouchBattle.enabled = isEnable;
    }
}
