using UnityEngine;

public class SelectorArmorListItem : SelectorListItem<Armor>
{
    //[SerializeField] private ItemUI itemUI;

    public override void SetData(Armor data)
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

    private void HandleOnSelected(SelectorListItem<Armor> listItem) 
    {
        // UIEvents.RaiseItemOverviewUpdateRequested(listItem.Data);
    }
}
