using UnityEngine;
using TMPro;

public class SelectorMoveListItemBattle : SelectorMoveListItem
{
    //[SerializeField] private ItemUI itemUI;
    [SerializeField] private TMP_Text textCost;

    public override void SetData(Move data)
    {
        base.SetData(data);
        bool isAfordable = BattleManager.Instance.Battle.BattleComponentTeam.DictTeam[BattleManager.Instance.Battle.BattleComponentTeam.BattleSideUser].TeamComponentCharacter.ListCharacterPointEntity[0].Character.CharacterComponentMove.IsAffordable(data);
        // CustomLog.Error($"{isAfordable}");
        // TODO change color of cost to red
    }

    public override void Clear()
    {
        base.Clear();
    }
}
