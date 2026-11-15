public class Character 
{
    public CharacterComponentAttributes CharacterComponentAttributes;
    public CharacterComponentPersistence CharacterComponentPersistence;
    public CharacterComponentConfig CharacterComponentConfig;
    public CharacterComponentElement CharacterComponentElement;
    public CharacterComponentSpeed CharacterComponentSpeed;
    public CharacterComponentSide CharacterComponentSide;
    public CharacterComponentBullet CharacterComponentBullet;
    public CharacterComponentStats CharacterComponentStats;
    public CharacterComponentMove CharacterComponentMove;
    public CharacterComponentLevel CharacterComponentLevel;

    public Character(CharacterData data, CharacterSaveData saveData)
    {
        CharacterComponentAttributes = new CharacterComponentAttributes(data);
        CharacterComponentPersistence = new CharacterComponentPersistence(this);
        CharacterComponentConfig = new CharacterComponentConfig();
        CharacterComponentElement = new CharacterComponentElement(data.Element0, data.Element1);
        CharacterComponentSpeed = new CharacterComponentSpeed(data, this, saveData);
        CharacterComponentSide = new CharacterComponentSide(data);
        CharacterComponentBullet = new CharacterComponentBullet(data);
        CharacterComponentStats = new CharacterComponentStats(data, this, saveData);
        CharacterComponentMove = new CharacterComponentMove(data, this);
        CharacterComponentLevel = new CharacterComponentLevel(this, saveData);
    }

}
