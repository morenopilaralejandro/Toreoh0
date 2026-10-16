using System.Collections.Generic;
using Aremoreno.Enums.Item;

public class ItemComponentShop
{
    private Dictionary<CurrencyType, int> dictPriceBuy = new();
    private Dictionary<CurrencyType, int> dictPriceSell = new();
    public bool IsSellable;

    public ItemComponentShop(ItemData data) 
    {
        IsSellable = data.IsSellable;

        dictPriceBuy = new Dictionary<CurrencyType, int>
        {
            { CurrencyType.Gold, data.PriceBuyGold },
            { CurrencyType.ExpertTokens, data.PriceBuyExpertTokens }
        };

        dictPriceSell = new Dictionary<CurrencyType, int>
        {
            { CurrencyType.Gold, data.PriceSellGold }
        };
    }

    public int GetPriceBuy(CurrencyType currencyType = CurrencyType.Gold) => dictPriceBuy[currencyType];
    public int GetPriceSell(CurrencyType currencyType = CurrencyType.Gold) => dictPriceSell[currencyType];
}
