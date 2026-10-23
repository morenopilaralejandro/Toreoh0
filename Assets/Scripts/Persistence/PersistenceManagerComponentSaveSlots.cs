using UnityEngine;

public class PersistenceManagerComponentSaveSlots
{
    public SaveSlot[] SaveSlots;

    public PersistenceManagerComponentSaveSlots(PersistenceConfig config) 
    {
        SaveSlots = new SaveSlot[config.SaveSlotCount];
        for (int i = 0; i < SaveSlots.Length; i++)
            SaveSlots[i] = new SaveSlot(i, config);
    }
}
