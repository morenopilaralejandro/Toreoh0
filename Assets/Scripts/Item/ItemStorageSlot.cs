[System.SerializeField]
public class ItemStorageSlot
{
    public Item Item;
    public int Count;

    public ItemStorageSlot(Item item, int amount = 1)
    {
        Item = item;
        Count = amount;
    }

    public void AddCount(int amount) 
    {
        Count += amount;
        if (Count > Item.MaxStack)
            Count = Item.MaxStack;
    }

    public void RemoveCount(int amount) 
    {
        Count -= amount;
        if (Count < 0)
            Count = 0;
    }
}
