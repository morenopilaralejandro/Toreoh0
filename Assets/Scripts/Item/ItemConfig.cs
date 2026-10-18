using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Item;

[CreateAssetMenu(fileName = "ItemConfig", menuName = "ScriptableObject/Item/ItemConfig")]
public class ItemConfig : ScriptableObject
{
    [Header("Debug")]
    public bool IsDebugStorage;
    public bool IsDebugCurrency;

    [Header("Bag")]
    public ItemCategory ItemCategoryDefaultBag;
    public ItemCategory[] ItemCategoryOrderBag;

    [Header("Currency")]
    public List<CurrencyMapping> ListCurrencyMapping;

    [Header("Storage")]
    public List<ItemData> ListStartingItemData;
}
