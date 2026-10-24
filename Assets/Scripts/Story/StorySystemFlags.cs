using System.Collections.Generic;

public class StorySystemFlags
{
    // fields
    private Dictionary<string, bool> dictFlags = new ();
    public IReadOnlyDictionary<string, bool> DictFlags => dictFlags;

    // lifecycle
    public StorySystemFlags() 
    {
        
    }

    // logic
    public void Set(string flagId, bool boolValue = true)
    {
        dictFlags[flagId] = boolValue;
        StoryEvents.RaiseStoryFlagChanged(flagId, boolValue);
    }

    public bool Get(string flagId)
    {
        if (dictFlags.TryGetValue(flagId, out bool boolValue))
            return boolValue;
        else
            return false;
    }

    public bool Has(string flagId) => dictFlags.ContainsKey(flagId);

    // persistence
    public void Clear()
    {
        dictFlags.Clear();
    }

    public void InitializeForNewGame() 
    {
        Clear();
        Set("game_new");
    }

    public StoryFlagsSystemSaveData Export() 
    {
        StoryFlagsSystemSaveData saveData = new();
        saveData.ListFlags = PersistenceParser.ParseDict<string, bool>(dictFlags);
        return saveData;
    }

    public void Import(StoryFlagsSystemSaveData saveData) 
    {
        Clear();
        foreach (var kvp in saveData.ListFlags)
            dictFlags[kvp.Key] = kvp.Val;
    }
}
