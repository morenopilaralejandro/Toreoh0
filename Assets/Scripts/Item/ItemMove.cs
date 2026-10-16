public class ItemMove : Item
{
    public ItemComponentMove MoveComponent;

    public ItemMove(ItemMoveData data) : base(data)
    {
        MoveComponent = new ItemComponentMove(data);
    }
}
