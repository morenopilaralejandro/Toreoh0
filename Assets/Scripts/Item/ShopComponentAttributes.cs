using Aremoreno.Enums.Item;

public class ShopComponentAttributes
{
    public string ShopId;
    public CurrencyType CurrencyType;

    public ShopComponentAttributes(ShopData data) 
    {
        ShopId = data.ShopId;
        CurrencyType = data.CurrencyType;
    }
}
