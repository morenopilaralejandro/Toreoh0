using System.Collections.Generic;

public class MoveManagerComponentStorage
{
    //fields
    public List<Move> ListMove = new();
    private MoveConfig config;

    // constructor
    public MoveManagerComponentStorage(MoveConfig config)
    {
        this.config = config;
    }

    // add
    public void Add(Move Move)
    {

    }

    // remove
    public void Remove(Move Move) 
    {

    }

    // query

    // persistence
    public void Clear()
    {
        ListMove.Clear();
    }

    public void InitializeForNewGame()
    {
        Clear();
        // Add default Move
    }

    public MoveManagerComponentStorageSaveData Export() 
    {
        MoveManagerComponentStorageSaveData saveData = new();
        saveData.ListMoveSaveData = new ();
        foreach (var Move in ListMove)
            saveData.ListMoveSaveData.Add(Move.MoveComponentPersistence.Export());
        return saveData;
    }

    public void Import(MoveManagerComponentStorageSaveData saveData) 
    {
        Clear();
        // import saveData
    }
}
