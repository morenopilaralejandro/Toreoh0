using System;
using 

public static class ItemEvents 
{
    public static event Action OnStorageUpdated;
    public static void RaiseStorageUpdated() 
        => OnStorageUpdated?.Invoke();

    public static event Action<CurrencyType, int> OnCurrencyUpdated;
    public static void RaiseCurrencyUpdated(CurrencyType currencyType, int count)
        => OnCurrencyUpdated?.Invoke(currencyType, count);
}
