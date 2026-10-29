public class Character 
{
    public CharacterComponentAttributes AttributesComponent;

    public Character(CharacterData data) 
    {
        AttributesComponent = new CharacterComponentAttributes(data);
    }
}
