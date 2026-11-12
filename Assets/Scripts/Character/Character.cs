public class Character 
{
    public CharacterComponentAttributes CharacterComponentAttributes;
    public CharacterComponentPersistence CharacterComponentPersistence;
    public CharacterComponentElement CharacterComponentElement;
    public CharacterComponentSpeed CharacterComponentSpeed;
    public CharacterComponentSide CharacterComponentSide;
    public CharacterComponentBullet CharacterComponentBullet;

    public Character(CharacterData data)
    {
        CharacterComponentAttributes = new CharacterComponentAttributes(data);
        CharacterComponentPersistence = new CharacterComponentPersistence(this);
        CharacterComponentElement = new CharacterComponentElement(data.Element0, data.Element1);
        CharacterComponentSpeed = new CharacterComponentSpeed(data, this, null);
        CharacterComponentSide = new CharacterComponentSide(data);
        CharacterComponentBullet = new CharacterComponentBullet(data);
    }
}
