public class ItemRecovery : Item
{
    public ItemComponentRecovery RecoveryComponent;

    public ItemRecovery(ItemDataRecovery data) : base(data)
    {
        RecoveryComponent = new ItemComponentRecovery(data);
    }
}
