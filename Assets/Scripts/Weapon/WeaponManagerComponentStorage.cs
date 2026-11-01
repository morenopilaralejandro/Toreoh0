using System.Collections.Generic;

public class WeaponManagerComponentStorage
{
    //fields
    public Dictionary<string, Weapon> DictWeapon = new();
    private WeaponConfig config;

    // constructor
    public WeaponManagerComponentStorage(WeaponConfig config)
    {
        this.config = config;
    }

    // add
    public void Add(Weapon Weapon)
    {

    }

    // remove
    public void Remove(Weapon Weapon) 
    {

    }

    // query

    // persistence
    public void Clear()
    {
        DictWeapon.Clear();
    }

    public void InitializeForNewGame()
    {
        Clear();
        // Add default Weapon
    }

    public WeaponManagerComponentStorageSaveData Export() 
    {
        WeaponManagerComponentStorageSaveData saveData = new();
        saveData.ListWeaponSaveData = new ();
        foreach (var Weapon in DictWeapon.Values)
            saveData.ListWeaponSaveData.Add(Weapon.WeaponComponentPersistence.Export());
        return saveData;
    }

    public void Import(WeaponManagerComponentStorageSaveData saveData) 
    {
        Clear();
        // import saveData
    }
}
