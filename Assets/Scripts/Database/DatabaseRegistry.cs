using System.Collections.Generic;

public class DatabaseRegistry
{
    // Fields
    public Database<SceneGroupData> SceneGroupData;
    public Database<ZoneData> ZoneData;
    public Database<NpcData> NpcData;
    public Database<ChestData> ChestData;
    public Database<ItemData> ItemData;
    public Database<ShopData> ShopData;

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
        NpcData = new Database<NpcData>("NpcData", _ => _.NpcId);
        ChestData = new Database<ChestData>("ChestData", _ => _.ChestId);
        ItemData = new Database<ItemData>("ItemData", _ => _.ItemId);
        ShopData = new Database<ShopData>("ShopData", _ => _.ShopId);
    }

    public IEnumerable<IAsyncDatabase> GetAllDatabases() 
    {
        yield return SceneGroupData;
        yield return ZoneData;
        yield return NpcData;
        yield return ChestData;
        yield return ItemData;
        yield return ShopData;
    }

}
