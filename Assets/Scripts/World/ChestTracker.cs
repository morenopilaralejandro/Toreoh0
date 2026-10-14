using System.Collections.Generic;

public class ChestTracker
{
    public string CurrentOpeningChestId { get; private set; }
    private HashSet<string> hashSetOpened = new();
    
    public void Clear()
    {
        hashSetOpened.Clear();
        CurrentOpeningChestId = string.Empty;
    }

    // hashSet
    public bool Contains(string chestId) => hashSetOpened.Contains(chestId);
    public void Add(string chestId) => hashSetOpened.Add(chestId);

    // current
    public void SetCurrentOpeningChestId(string chestId) => CurrentOpeningChestId = chestId;
    public void ClearCurrentOpeningChestId() => CurrentOpeningChestId = string.Empty;

    // persistence
    public ChestSystemSaveData Export() 
    {
        return new ChestSystemSaveData 
        {
            ListOpened = PersistenceParser.ParseHashSet<string>(hashSetOpened)
        };
    }

    public void Import(ChestSystemSaveData saveData) 
    {
        Clear();
        foreach (string chestId in saveData.ListOpened) 
            hashSetOpened.Add(chestId);
    }
}
