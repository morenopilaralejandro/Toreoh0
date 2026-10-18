public class Shop
{
    public ShopComponentAttributes AttributesComponent;
    public ShopComponentLocalization LocalizationComponent;
    public ShopComponentItems ItemsComponent;

    public Shop(ShopData data)
    {
        AttributesComponent = new ShopComponentAttributes(data);
        LocalizationComponent = new ShopComponentLocalization(data);
        ItemsComponent = new ShopComponentItems(data);
    }
}
