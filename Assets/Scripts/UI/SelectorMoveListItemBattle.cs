using UnityEngine;
using TMPro;

public class SelectorMoveListItemBattle : SelectorMoveListItem
{
    //[SerializeField] private ItemUI itemUI;

    public override void SetData(Move data)
    {
        bool isAffordable = BattleManager.Instance.Battle.BattleComponentTeam.DictTeam[BattleManager.Instance.Battle.BattleComponentTeam.BattleSideUser].TeamComponentCharacter.ListCharacterPointEntity[0].Character.CharacterComponentMove.IsAffordable(data);
        moveUI.SetCostColor(isAffordable);
        base.SetData(data);
    }
}
