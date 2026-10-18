using UnityEngine;

public class SelectorItemStorageSlotBagListItem : SelectorListItem<ItemStorageSlot>
{
    [SerializeField] private ItemUI itemUI;

    public override void SetData(ItemStorageSlot data)
    {
        base.SetData(data);
        _ =  itemUI.SetAsync(data.Item, data.Count);
        OnSelected += HandleOnSelected;
    }

    public override void Clear()
    {
        itemUI.Clear();
        OnSelected -= HandleOnSelected;
    }

    private void HandleOnSelected(SelectorListItem<ItemStorageSlot> listItem) 
    {
        UIEvents.RaiseItemOverviewUpdateRequested(listItem.Data.Item);
    }
}
