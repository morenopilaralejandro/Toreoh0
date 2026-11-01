using System.Collections.Generic;

public class ArmorManagerComponentStorage
{
    //fields
    public Dictionary<string, Armor> DictArmor = new();
    private ArmorConfig config;

    // constructor
    public ArmorManagerComponentStorage(ArmorConfig config)
    {
        this.config = config;
    }

    // add
    public void Add(Armor Armor)
    {

    }

    // remove
    public void Remove(Armor Armor) 
    {

    }

    // query

    // persistence
    public void Clear()
    {
        DictArmor.Clear();
    }

    public void InitializeForNewGame()
    {
        Clear();
        // Add default Armor
    }

    public ArmorManagerComponentStorageSaveData Export() 
    {
        ArmorManagerComponentStorageSaveData saveData = new();
        saveData.ListArmorSaveData = new ();
        foreach (var Armor in DictArmor.Values)
            saveData.ListArmorSaveData.Add(Armor.ArmorComponentPersistence.Export());
        return saveData;
    }

    public void Import(ArmorManagerComponentStorageSaveData saveData) 
    {
        Clear();
        // import saveData
    }
}
