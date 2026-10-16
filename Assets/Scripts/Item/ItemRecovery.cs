public class ItemRecovery : Item
{
    public ItemComponentRecovery RecoveryComponent;

    public ItemRecovery(ItemRecoveryData data) : base(data)
    {
        RecoveryComponent = new ItemComponentRecovery(data);
    }
}
