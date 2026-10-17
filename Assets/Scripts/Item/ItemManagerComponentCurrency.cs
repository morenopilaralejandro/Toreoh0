using System;
using System.Collections.Generic;
using Aremoreno.Enums.Item;

public class ItemManagerComponentCurrency
{
    //fields
    private ItemConfig config;
    private Dictionary<CurrencyType, CurrencyMapping> dictMapping = new();
    private Dictionary<CurrencyType, int> dictCurrency = new();
    public IReadOnlyDictionary<CurrencyType, int> DictCurrency => dictCurrency;

    // constructor
    public ItemManagerComponentCurrency(ItemConfig config)
    {
        this.config = config;
        BuildDict();
    }

    // helper
    private void BuildDict() 
    {
        foreach (var mapping in config.ListCurrencyMapping)
            dictMapping[mapping.CurrencyType] = mapping;
    }

    private void Clamp(CurrencyType currencyType)
    {
        int minValue = dictMapping[currencyType].MinValue; 
        int maxValue = dictMapping[currencyType].MaxValue;
        int currentValue = dictCurrency[currencyType];
        dictCurrency[currencyType] = Math.Clamp(currentValue, maxValue, maxValue);
    }


    // logic
    public void Add(CurrencyType currencyType, int count)
    {
        dictCurrency[currencyType] += count;
        Clamp(currencyType);
        ItemEvents.RaiseCurrencyUpdated(currencyType, dictCurrency[currencyType]);
    }

    public void Remove(CurrencyType currencyType, int count)
    {
        dictCurrency[currencyType] -= count;
        Clamp(currencyType);
        ItemEvents.RaiseCurrencyUpdated(currencyType, dictCurrency[currencyType]);
    }

    public int Get(CurrencyType currencyType) => dictCurrency[currencyType];
    public void Set(CurrencyType currencyType, int count) => dictCurrency[currencyType] = count;
    public bool HasEnoughOfCurrency(CurrencyType currencyType, int count) => dictCurrency[currencyType] >= count;

    // persistence
    public void Clear()
    {
        dictCurrency.Clear();
    }

    public void InitializeForNewGame()
    {
        Clear();
        bool isDebug = DebugUtils.IsDevBuild && config.IsDebugCurrency;
        foreach (var mapping in config.ListCurrencyMapping) 
            dictCurrency[mapping.CurrencyType] = isDebug ? mapping.MaxValue : mapping.DefaultValue;
    }

    public ItemManagerComponentCurrencySaveData Export() 
    {
        ItemManagerComponentCurrencySaveData saveData = new();
        saveData.ListCurrency = PersistenceParser.ParseDict<CurrencyType, int>(dictCurrency);
        return saveData;
    }

    public void Import(ItemManagerComponentCurrencySaveData saveData) 
    {
        Clear();
        foreach (var kvp in saveData.ListCurrency)
            dictCurrency[kvp.Key] = kvp.Val;
    }
}
