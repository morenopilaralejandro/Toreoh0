using System.Collections.Generic;

public class DatabaseRegistry
{
    // Fields
    public Database<SceneGroupData> SceneGroupData;
    public Database<ZoneData> ZoneData;

    // Constructor
    public DatabaseRegistry() 
    {
        CreateDatabases();
    }

    private void CreateDatabases() 
    {
        // use addresable tags - labels
        // CharacterData = new Database<CharacterData>("CharacterData", _ => _.CharacterId);
        SceneGroupData = new Database<SceneGroupData>("SceneGroupData", _ => _.SceneGroupId);
        ZoneData = new Database<ZoneData>("ZoneData", _ => _.ZoneId);
    }

    public IEnumerable<IAsyncDatabase> GetAllDatabases() 
    {
        yield return SceneGroupData;
        yield return ZoneData;
    }

}
