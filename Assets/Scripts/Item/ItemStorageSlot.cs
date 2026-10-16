[System.Serializable]
public class ItemStorageSlot
{
    public Item Item;
    public int Count = 1;

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
