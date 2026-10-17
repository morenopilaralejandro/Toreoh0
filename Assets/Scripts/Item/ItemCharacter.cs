public class ItemCharacter : Item
{
    public ItemComponentCharacter CharacterComponent;

    public ItemCharacter(ItemDataCharacter data) : base(data)
    {
        CharacterComponent = new ItemComponentCharacter(data);
    }
}
