using System.Collections.Generic;

public class WingManagerComponentStorage
{
    //fields
    public List<Wing> ListWing = new();
    private WingConfig config;

    // constructor
    public WingManagerComponentStorage(WingConfig config)
    {
        this.config = config;
    }

    // add
    public void Add(Wing Wing)
    {

    }

    // remove
    public void Remove(Wing Wing) 
    {

    }

    // query

    // persistence
    public void Clear()
    {
        ListWing.Clear();
    }

    public void InitializeForNewGame()
    {
        Clear();
        // Add default Wing
    }

    public WingManagerComponentStorageSaveData Export() 
    {
        WingManagerComponentStorageSaveData saveData = new();
        saveData.ListWingSaveData = new ();
        foreach (var Wing in ListWing)
            saveData.ListWingSaveData.Add(Wing.WingComponentPersistence.Export());
        return saveData;
    }

    public void Import(WingManagerComponentStorageSaveData saveData) 
    {
        Clear();
        // import saveData
    }
}
