public class CharacterComponentSpeed
{
    private Character character;
    private float speedMovement;
    private float baseMultiplier = 0.005f;
    //private float minSpeed = 0.1f;
    //private float maxSpeed = 1f;

    public float SpeedMovement => speedMovement;

    public CharacterComponentSpeed(CharacterData data, Character character, CharacterSaveData saveData)
    {
        this.character = character;
        UpdateSpeed();
    }

    public void UpdateSpeed() 
    {
        //speedMovement = character.speedstat * baseMultiplier * other things that affect speed 
        speedMovement = 100f * baseMultiplier;
        // speedMovement = Mathf.Clamp(speedMovement, minSpeed, maxSpeed);
    }
}
