public class ItemCharacter : Item
{
    public ItemComponentCharacter CharacterComponent;

    public ItemCharacter(ItemCharacterData data) : base(data)
    {
        CharacterComponent = new ItemComponentCharacter(data);
    }
}
