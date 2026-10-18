public class ItemWing : Item
{
    public ItemComponentWing WingComponent;

    public ItemWing(ItemDataWing data) : base(data)
    {
        WingComponent = new ItemComponentWing(data);
    }
}
