public class ItemMisc : Item
{
    public ItemComponentMisc MiscComponent;

    public ItemMisc(ItemMiscData data) : base(data)
    {
        MiscComponent = new ItemComponentMisc(data);
    }
}
