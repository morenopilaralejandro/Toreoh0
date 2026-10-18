public class ItemMisc : Item
{
    public ItemComponentMisc MiscComponent;

    public ItemMisc(ItemDataMisc data) : base(data)
    {
        MiscComponent = new ItemComponentMisc(data);
    }
}
