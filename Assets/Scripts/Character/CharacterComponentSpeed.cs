using UnityEngine;
using Aremoreno.Enums.Character;

public class CharacterComponentSpeed
{
    private Character character;
    private float speedMovement;
    private float baseMultiplier = 0.05f;
    private float minSpeed = 0.1f;
    private float maxSpeed = 9999f;

    public float SpeedMovement => speedMovement;

    public CharacterComponentSpeed(CharacterData data, Character character, CharacterSaveData saveData)
    {
        this.character = character;
        RecalculateSpeed();
    }

    public void RecalculateSpeed()
    {
        speedMovement = 
            character.CharacterComponentStats.StatsBattle.Get(Stat.Speed) * 
            baseMultiplier *
            character.CharacterComponentFatigue.FatigueMultiplier;
        speedMovement = Mathf.Clamp(speedMovement, minSpeed, maxSpeed);
    }
}
