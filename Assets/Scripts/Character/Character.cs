public class Character 
{
    public CharacterComponentAttributes CharacterComponentAttributes;
    public CharacterComponentPersistence CharacterComponentPersistence;
    public CharacterComponentConfig CharacterComponentConfig;
    public CharacterComponentAppearance CharacterComponentAppearance;
    public CharacterComponentElement CharacterComponentElement;
    public CharacterComponentSpeed CharacterComponentSpeed;
    public CharacterComponentSide CharacterComponentSide;
    public CharacterComponentBullet CharacterComponentBullet;
    public CharacterComponentLevel CharacterComponentLevel;
    public CharacterComponentStats CharacterComponentStats;
    public CharacterComponentMove CharacterComponentMove;

    public Character(CharacterData data, CharacterSaveData saveData)
    {
        CharacterComponentAttributes = new CharacterComponentAttributes(data);
        CharacterComponentPersistence = new CharacterComponentPersistence(this);
        CharacterComponentConfig = new CharacterComponentConfig();
        CharacterComponentAppearance = new CharacterComponentAppearance(data);
        CharacterComponentElement = new CharacterComponentElement(data.Element0, data.Element1);
        CharacterComponentSpeed = new CharacterComponentSpeed(data, this, saveData);
        CharacterComponentSide = new CharacterComponentSide(data);
        CharacterComponentBullet = new CharacterComponentBullet(data);
        CharacterComponentLevel = new CharacterComponentLevel(this, saveData);
        CharacterComponentStats = new CharacterComponentStats(data, this, saveData);
        CharacterComponentMove = new CharacterComponentMove(data, this);
    }
}
