using System.Collections.Generic;

public class CharacterManagerComponentStorage
{
    //fields
    public List<Character> ListCharacter = new();
    private CharacterConfig config;

    // constructor
    public CharacterManagerComponentStorage(CharacterConfig config)
    {
        this.config = config;
    }

    // add
    public void Add(Character Character)
    {

    }

    // remove
    public void Remove(Character Character) 
    {

    }

    // query

    // persistence
    public void Clear()
    {
        ListCharacter.Clear();
    }

    public void InitializeForNewGame()
    {
        Clear();
        // Add default Character
    }

    public CharacterManagerComponentStorageSaveData Export() 
    {
        CharacterManagerComponentStorageSaveData saveData = new();
        saveData.ListCharacterSaveData = new ();
        foreach (var character in ListCharacter)
            saveData.ListCharacterSaveData.Add(character.CharacterComponentPersistence.Export());
        return saveData;
    }

    public void Import(CharacterManagerComponentStorageSaveData saveData) 
    {
        Clear();
        // import saveData
    }
}
