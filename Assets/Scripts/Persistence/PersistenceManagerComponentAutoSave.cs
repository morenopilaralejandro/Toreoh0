using UnityEngine;

public class PersistenceManagerComponentAutoSave
{
    public SaveSlot SaveSlot;

    public PersistenceManagerComponentAutoSave(SaveSlot saveSlot) 
    {
        SaveSlot = saveSlot;
        SaveSlot.SetIsAutoSave(true);
    }
}
