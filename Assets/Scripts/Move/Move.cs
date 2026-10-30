public class Move 
{
    public MoveComponentAttributes MoveComponentAttributes;
    public MoveComponentPersistence MoveComponentPersistence;

    public Move(MoveData data)
    {
        MoveComponentAttributes = new MoveComponentAttributes(data);
        MoveComponentPersistence = new MoveComponentPersistence(this);
    }
}
