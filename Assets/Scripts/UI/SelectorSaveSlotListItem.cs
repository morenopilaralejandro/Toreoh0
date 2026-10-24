using UnityEngine;

public class SelectorSaveSlotListItem : SelectorListItem<SaveSlot>
{
    [SerializeField] private SaveFileCardMini card;
    private SaveData saveData;

    public override void SetData(SaveSlot data)
    {
        base.SetData(data);
        card.SetIndex(data.SlotIndex);
        if (data.Writer.TryGetLastSaveData(out saveData))
            card.SetData(saveData);
        else
            card.Clear();
        OnSelected += HandleOnSelected;
    }

    public override void Clear()
    {
        card.Clear();
        OnSelected -= HandleOnSelected;
    }

    private void HandleOnSelected(SelectorListItem<SaveSlot> listItem) 
    {
        UIEvents.RaiseSaveDataOverviewUpdateRequested(saveData);
    }
}
