using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Battle;

public class BattleResultComponentItem
{
    public List<ItemReward> ListItemReward;

    public BattleResultComponentItem(BattleResultSaveData saveData)
    {
        ListItemReward = saveData.ListItemReward;
    }
}
