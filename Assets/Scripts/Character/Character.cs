public class Character 
{
    public CharacterComponentAttributes CharacterComponentAttributes;
    public CharacterComponentPersistence CharacterComponentPersistence;
    public CharacterComponentElement CharacterComponentElement;
    public CharacterComponentSpeed CharacterComponentSpeed;

    public Character(CharacterData data)
    {
        CharacterComponentAttributes = new CharacterComponentAttributes(data);
        CharacterComponentPersistence = new CharacterComponentPersistence(this);
        CharacterComponentElement = new CharacterComponentElement(data.ListElement);
        CharacterComponentSpeed = new CharacterComponentSpeed(data, this, null);
    }
}
