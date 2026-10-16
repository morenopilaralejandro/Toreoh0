public class ItemWing : Item
{
    public ItemComponentWing WingComponent;

    public ItemWing(ItemWingData data) : base(data)
    {
        WingComponent = new ItemComponentWing(data);
    }
}
