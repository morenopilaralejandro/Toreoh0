public class WorldZoneLoader 
{

    databaseManager

    chunkStreaming

    sceneLoader

    // position
    LoadZoneAtPosition 
    {
        zoneTracker.SetZone(zone);

        if (zone.ZoneType == ZoneType.Overworld)
            LoadZoneAtPositionOverworld();
        else
            LoadZoneAtPositionInterior();
                
    }

    LoadZoneAtPositionOverworld() 
    {
        character.Teleport();
        character.SetFacing();
        chunkStreaming.UpdateChunksAroundCharacter();
        chunkStreaming.StartStreaming(zone.OverworldData);
        // state in overworld
    }

    LoadZoneAtPositionInterior 
    {
        sceneLoader.LoadScenes(new string[] { zone.SceneAddressInterior });
        character.Teleport();
        character.SetFacing();
        // state in interior
    }

    // SpawnPoint
    LoadZoneAtSpawnPoint(ZoneData zone, string spawnId) 
    {
        SpawnPoint spawnPoint = spawnPointRegistry.FindSpawnPoint(zone.ZoneId, spawnId);
        LoadZoneAtPosition(zone, spawnPoint.GetSpawnPosition(), spawnPoint.FacingDirection());       
    }

    // Unload
    UnloadCurrentZone() 
    {
        chunkStreaming.StopStreaming();
        sceneLoader.UnloadAll();
    }

    // other
    LoadZoneFromUnloaded() 
    {
        // state transitioning
        get zone from world args
WorldArgs.ZoneId
get zone data form the database

        LoadZoneAtPosition(WorldArgs.ZoneId, WorldArgs.CharacterPosition, WorldArgs.FacingDirection);
    }

    public void TransitionToZone() 
    {
        // if state is transitioning return
        UnloadCurrentZone();
        LoadZoneAtSpawnPoint(zone, spawnId);
    }

    
}
