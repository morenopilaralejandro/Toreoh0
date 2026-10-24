using UnityEngine;
using Aremoreno.Enums.UI;

public class SelectorSaveSlotActionClickSave : ISelectorActionClick<SaveSlot>
{
    public void Execute(SaveSlot obj, IMenuClosable menu)
    {
        if (obj.IsAutoSave) return;
        UIEvents.RaiseDialogConfirmOpenRequestedByMessageType(DialogConfrimMessageType.OverwriteSaveData);
    }
}
