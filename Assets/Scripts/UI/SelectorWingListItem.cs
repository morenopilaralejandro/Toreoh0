using UnityEngine;

public class SelectorWingListItem : SelectorListItem<Wing>
{
    //[SerializeField] private ItemUI itemUI;

    public override void SetData(Wing data)
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

    private void HandleOnSelected(SelectorListItem<Wing> listItem) 
    {
        // UIEvents.RaiseItemOverviewUpdateRequested(listItem.Data);
    }
}
