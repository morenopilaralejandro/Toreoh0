using UnityEngine;

public class SelectorMoveListItem : SelectorListItem<Move>
{
    //[SerializeField] private ItemUI itemUI;

    public override void SetData(Move data)
    {
        base.SetData(data);
        //_ =  itemUI.SetAsync(data);
        OnSelected += HandleOnSelected;
    }

    public override void Clear()
    {
        //itemUI.Clear();
        OnSelected -= HandleOnSelected;
    }

    private void HandleOnSelected(SelectorListItem<Move> listItem) 
    {
        // UIEvents.RaiseItemOverviewUpdateRequested(listItem.Data);
    }
}
