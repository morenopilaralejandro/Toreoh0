using Aremoreno.Enums.Item;

public class ItemComponentAttributes
{
    public string ItemId;
    public ItemCategory ItemCategory;

    public ItemComponentAttributes(ItemData data) 
    {
        ItemId = data.ItemId;
        ItemCategory = data.ItemCategory;
    }
}
