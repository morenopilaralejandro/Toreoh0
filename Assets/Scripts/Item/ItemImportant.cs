public class ItemImportant : Item
{
    public ItemComponentImportant ImportantComponent;

    public ItemImportant(ItemDataImportant data) : base(data)
    {
        ImportantComponent = new ItemComponentImportant(data);
    }
}
