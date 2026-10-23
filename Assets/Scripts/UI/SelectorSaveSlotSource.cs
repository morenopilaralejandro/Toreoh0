using System.Collections.Generic;

public class SelectorSaveSlotSource : ISelectorSource<SaveSlot>
{
    public IEnumerable<SaveSlot> Enumerate() => 
        PersistenceManager.Instance.SaveSlotsComponent.SaveSlots;
}
