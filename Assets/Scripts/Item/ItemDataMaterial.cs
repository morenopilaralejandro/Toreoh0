using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Input;

[CreateAssetMenu(fileName = "ItemDataMaterial", menuName = "ScriptableObject/Item/ItemDataMaterial")]
public class ItemDataMaterial : ItemData
{
    public int TestInt;
    public float TestFloat;
    public bool TestBool;
    public InputBattle TestInputBattle;
    public List<ItemReward> TestItemRewardList;
}
