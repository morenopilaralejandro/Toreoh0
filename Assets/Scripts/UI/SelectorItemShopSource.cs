using System.Collections.Generic;

public class SelectorItemShopSource : ISelectorSource<Item>
{
    public Shop Shop;
    
    public SelectorItemShopSource(Shop shop)
    {
        Shop = shop;
    }

    public IEnumerable<Item> Enumerate() => Shop.ItemsComponent.Items;
}
