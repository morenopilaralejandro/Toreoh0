using UnityEngine;
using Aremoreno.Enum.Color;
using Aremoreno.Enum.Item;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/Item/ItemData")]
public class ItemData : ScriptableObject
{
    public string ItemId;
    public ItemCategory ItemCategory;
    public ItemUsageContext ItemUsageContext;
    public ItemSpriteType ItemSpriteType;
    public ColorGeneric ColorGeneric;
    public int PriceBuyExpertTokens;
    public int PriceBuyGold;
    public int PriceSellGold;
    public bool IsSellable;
    public bool IsDiscardable;
    public bool IsStackable;
    public int MaxStack;
}
