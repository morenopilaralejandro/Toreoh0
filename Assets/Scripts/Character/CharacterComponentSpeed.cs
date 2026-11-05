public class CharacterComponentSpeed
{
    private Character character;
    private float speedMovement;
    //private float baseMultiplier = 0.1f;
    //private float minSpeed = 1.0f;
    //private float maxSpeed = 10.0f;

    public float SpeedMovement => speedMovement;

    public CharacterComponentSpeed(CharacterData data, Character character, CharacterSaveData saveData)
    {
        this.character = character;
    }

    public void UpdateSpeed() 
    {
        //speedMovement = character.speedstat * baseMultiplier * other things that affect speed 
        speedMovement = 5f;
        // speedMovement = Mathf.Clamp(speedMovement, minSpeed, maxSpeed);
    }
}
