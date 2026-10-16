public class ItemComponentInventory
{
    public ItemUsageContext ItemUsageContext;
    public bool IsDiscardable;
    public bool IsStackable;
    public int MaxStack;

    public ItemComponentInventory(ItemData data) 
    {
        ItemUsageContext = data.ItemUsageContext;
        IsDiscardable = data.IsDiscardable;
        IsStackable = data.IsStackable;
        MaxStack = data.MaxStack;
    }
}
