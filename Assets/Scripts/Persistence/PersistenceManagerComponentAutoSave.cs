using UnityEngine;

public class PersistenceManagerComponentAutoSave
{
    public SaveSlot SaveSlot;

    public PersistenceManagerComponentAutoSave(SaveSlot saveSlot) 
    {
        SaveSlot = saveSlot;
        SaveSlot.SetIsAutoSave(true);
    }

    public void Subscribe() 
    {
        PersistenceEvents.OnAutoSaveRequested += OnAutoSaveRequested;
    }

    public void Unsubscribe() 
    {
        PersistenceEvents.OnAutoSaveRequested -= OnAutoSaveRequested;
    }

    private void OnAutoSaveRequested() 
    {
        if (!SettingsManager.Instance.Settings.Common.IsAutoSaveEnabled) return;
        SaveSlot.Saver.SaveGame();
    }
}
