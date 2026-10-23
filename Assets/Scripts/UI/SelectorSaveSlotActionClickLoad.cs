using UnityEngine;
using Aremoreno.Enums.UI;

public class SelectorSaveSlotActionClickLoad : ISelectorActionClick<SaveSlot>
{
    public void Execute(SaveSlot obj, IMenuClosable menu)
    {
        if (!obj.Writer.HasSaveData) return;
        obj.Loader.LoadGame();
        UIEvents.RaiseSelectorSaveSlotCloseRequested();
        SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-World");
    }
}
