public class SelectorItemStorageSlotBagActionClickUse : ISelectorActionClick<ItemStorageSlot>
{
    public void Execute(ItemStorageSlot obj, IMenuClosable menu)
    {
        // DialogEvents.RaiseChoiceSelected(obj.ChoiceIndex);
        CustomLog.Error($"[SelectorItemStorageSlotBagActionClickUse] {obj.Item.AttributesComponent.ItemId}");
    }
}
