using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Item;

[CreateAssetMenu(fileName = "ShopData", menuName = "ScriptableObject/Item/ShopData")]
public class ShopData : ScriptableObject
{
    public string ShopId;
    public CurrencyType CurrencyType;
    public List<string> ItemIds;
}
