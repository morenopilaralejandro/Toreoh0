public class Character 
{
    public CharacterComponentAttributes CharacterComponentAttributes;
    public CharacterComponentPersistence CharacterComponentPersistence;
    public CharacterComponentConfig CharacterComponentConfig;
    public CharacterComponentAppearance CharacterComponentAppearance;
    public CharacterComponentElement CharacterComponentElement;
    public CharacterComponentSide CharacterComponentSide;
    public CharacterComponentBullet CharacterComponentBullet;
    public CharacterComponentLevel CharacterComponentLevel;
    public CharacterComponentStats CharacterComponentStats;
    public CharacterComponentFatigue CharacterComponentFatigue;
    public CharacterComponentSpeed CharacterComponentSpeed;
    public CharacterComponentMove CharacterComponentMove;
    public CharacterComponentAIScalingDifficulty CharacterComponentAIScalingDifficulty;
    public CharacterComponentAIScalingHp CharacterComponentAIScalingHp;

    public Character(CharacterData data, CharacterSaveData saveData)
    {
        CharacterComponentAttributes = new CharacterComponentAttributes(data);
        CharacterComponentPersistence = new CharacterComponentPersistence(this);
        CharacterComponentConfig = new CharacterComponentConfig();
        CharacterComponentAppearance = new CharacterComponentAppearance(data);
        CharacterComponentElement = new CharacterComponentElement(data.Element0, data.Element1);
        CharacterComponentSide = new CharacterComponentSide(data);
        CharacterComponentBullet = new CharacterComponentBullet(data);
        CharacterComponentLevel = new CharacterComponentLevel(this, saveData);
        CharacterComponentStats = new CharacterComponentStats(data, this, saveData);
        CharacterComponentFatigue = new CharacterComponentFatigue(this);
        CharacterComponentSpeed = new CharacterComponentSpeed(data, this, saveData);
        CharacterComponentMove = new CharacterComponentMove(data, this);
        CharacterComponentAIScalingDifficulty = new CharacterComponentAIScalingDifficulty(this);
        CharacterComponentAIScalingHp = new CharacterComponentAIScalingHp(this);
    }
}
