using UnityEngine;

public class SelectorItemShopListItem : SelectorListItem<Item>
{
    [SerializeField] private ItemUI itemUI;

    public override void SetData(Item data)
    {
        base.SetData(data);
        _ =  itemUI.SetAsync(data);
        OnSelected += HandleOnSelected;
    }

    public override void Clear()
    {
        itemUI.Clear();
        OnSelected -= HandleOnSelected;
    }

    private void HandleOnSelected(SelectorListItem<Item> listItem) 
    {
        UIEvents.RaiseItemOverviewUpdateRequested(listItem.Data);
    }
}
