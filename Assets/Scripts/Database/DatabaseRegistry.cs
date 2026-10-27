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
    public Database<FieldData> FieldData;
    public Database<ProtectObstacleData> ProtectObstacleData;
    public Database<FormationCoordData> FormationCoordData;
    //public Database<FormationData> FormationData;
    public Database<BarrierData> BarrierData;
    public Database<CapturePortalData> CapturePortalData;

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
        FieldData = new Database<FieldData>("FieldData", _ => _.FieldId);
        ProtectObstacleData = new Database<ProtectObstacleData>("ProtectObstacleData", _ => _.ProtectObstacleId);
        FormationCoordData = new Database<FormationCoordData>("FormationCoordData", _ => _.FormationCoordId);
        //FormationData = new Database<FormationData>("FormationData", _ => _.FormationId);
        BarrierData = new Database<BarrierData>("BarrierData", _ => _.BarrierId);
        CapturePortalData = new Database<CapturePortalData>("CapturePortalData", _ => _.CapturePortalId);
    }

    public IEnumerable<IAsyncDatabase> GetAllDatabases() 
    {
        yield return SceneGroupData;
        yield return ZoneData;
        yield return NpcData;
        yield return ChestData;
        yield return ItemData;
        yield return ShopData;
        yield return FieldData;
        yield return ProtectObstacleData;
        yield return FormationCoordData;
        //yield return FormationData;
        yield return BarrierData;
        yield return CapturePortalData;
    }

}
