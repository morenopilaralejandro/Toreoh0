public class Item
{
    public ItemComponentAttributes AttributesComponent;
    public ItemComponentLocalization LocalizationComponent;
    public ItemComponentAppearance AppearanceComponent;
    public ItemComponentInventory InventoryComponent;
    public ItemComponentShop ShopComponent;

    public Item(ItemData ItemData)
    {
        AttributesComponent = new ItemComponentAttributes(data);
        LocalizationComponent = new ItemComponentLocalization(data);
        AppearanceComponent = new ItemComponentAppearance(data);
        InventoryComponent = new ItemComponentInventory(data);
        ShopComponent = new ItemComponentShop(data);
    }
}
