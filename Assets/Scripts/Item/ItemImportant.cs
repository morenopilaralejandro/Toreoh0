public class ItemImportant : Item
{
    public ItemComponentImportant ImportantComponent;

    public ItemImportant(ItemImportantData data) : base(data)
    {
        ImportantComponent = new ItemComponentImportant(data);
    }
}
