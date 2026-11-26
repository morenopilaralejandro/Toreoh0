using UnityEngine;

public class SelectorMoveListItem : SelectorListItem<Move>
{
    [SerializeField] protected MoveUI moveUI;

    public override void SetData(Move data)
    {
        base.SetData(data);
        _ =  moveUI.SetAsync(data);
        OnSelected += HandleOnSelected;
    }

    public override void Clear()
    {
        moveUI.Clear();
        OnSelected -= HandleOnSelected;
    }

    private void HandleOnSelected(SelectorListItem<Move> listItem) 
    {
        UIEvents.RaiseMoveOverviewUpdateRequested(listItem.Data);
    }
}
