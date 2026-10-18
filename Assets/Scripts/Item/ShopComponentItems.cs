using System.Collections.Generic;
using Aremoreno.Enums.Item;

public class ShopComponentItems
{
    public List<Item> Items = new ();

    public ShopComponentItems(ShopData data) 
    {
        foreach (string itemId in data.ItemIds)
            Items.Add(ItemFactory.CreateById(itemId));
    }
}
