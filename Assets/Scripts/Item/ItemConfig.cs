using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ItemConfig", menuName = "ScriptableObject/Item/ItemConfig")]
public class ItemConfig : ScriptableObject
{
    [Header("Debug")]
    public bool IsDebugStorage;
    public bool IsDebugCurrency;

    [Header("Currency")]
    public List<CurrencyMapping> ListCurrencyMapping;

    [Header("Storage")]
    public List<ItemData> ListStartingItemData;
}
