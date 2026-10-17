public class ItemMove : Item
{
    public ItemComponentMove MoveComponent;

    public ItemMove(ItemDataMove data) : base(data)
    {
        MoveComponent = new ItemComponentMove(data);
    }
}
