using UnityEngine;
using TMPro;

public class SelectorItemStorageSlotBagListItem : SelectorListItem<ItemStorageSlot>
{
    [SerializeField] private TMP_Text textChoice;
    [SerializeField] private TMP_Text textChoice;
    [SerializeField] private TMP_Text textChoice;

    public override void SetData(ItemStorageSlot data)
    {
        base.SetData(data);
        textChoice.text = data.TextResolved;
    }

    public override void Clear()
    {
        textChoice.text = string.Empty;
    }

    // TODO select event to update the description
}
