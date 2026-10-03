using UnityEngine;
using Aremoreno.Enums.Animation;
using Aremoreno.Enums.World;

public class WorldZoneLoader 
{
    private DatabaseManager databaseManager;
    private CharacterEntityWorld character;
    private WorldChunkStreaming chunkStreaming;
    private WorldSceneLoader sceneLoader;
    private WorldZoneTracker zoneTracker;
    private SpawnPointRegistry spawnPointRegistry;

    public WorldZoneLoader(
        DatabaseManager databaseManager, 
        CharacterEntityWorld character, 
        WorldChunkStreaming chunkStreaming, 
        WorldSceneLoader sceneLoader, 
        WorldZoneTracker zoneTracker, 
        SpawnPointRegistry spawnPointRegistry)
    {
        this.databaseManager = databaseManager;
        this.character = character;
        this.chunkStreaming = chunkStreaming;
        this.sceneLoader = sceneLoader;
        this.zoneTracker = zoneTracker;
        this.spawnPointRegistry = spawnPointRegistry;
    }

    // position
    public void LoadZoneAtPosition(ZoneData zoneData, Vector3 pos, CharacterDirection facingDirection)
    {
        zoneTracker.SetZone(zoneData);
        if (zoneData.ZoneType == ZoneType.Overworld)
            LoadZoneAtPositionOverworld(zoneData, pos, facingDirection);
        else
            LoadZoneAtPositionInterior(zoneData, pos, facingDirection);
    }

    public void LoadZoneAtPositionOverworld(ZoneData zoneData, Vector3 pos, CharacterDirection facingDirection) 
    {
        character.Teleport(pos);
        character.SetFacing(facingDirection);
        chunkStreaming.UpdateChunksAroundCharacter();
        chunkStreaming.StartStreaming(zoneData.OverworldData);
        // state in overworld
    }

    public void LoadZoneAtPositionInterior(ZoneData zoneData, Vector3 pos, CharacterDirection facingDirection)
    {
        sceneLoader.LoadScenes(new string[] { zoneData.SceneAddressInterior });
        character.Teleport(pos);
        character.SetFacing(facingDirection);
        // state in interior
    }

    // SpawnPoint
    public void LoadZoneAtSpawnPoint(ZoneData zoneData, string spawnPointId) 
    {
        SpawnPoint spawnPoint = spawnPointRegistry.GetSpawnPoint(spawnPointId);
        LoadZoneAtPosition(zoneData, spawnPoint.SpawnPosition, spawnPoint.FacingDirection);       
    }

    // Unload
    public void UnloadCurrentZone() 
    {
        chunkStreaming.StopStreaming();
        sceneLoader.UnloadAll();
    }

    // other
    public void LoadZoneFromUnloaded()
    {
        // state transitioning
        LoadZoneAtPosition(
            databaseManager.DatabaseRegistry.ZoneData.Get(WorldArgs.ZoneId),
            WorldArgs.CharacterPosition, 
            WorldArgs.CharacterFacingDirection);
    }

    public void TransitionToZone(ZoneData zoneData, string spawnPointId)
    {
        // if state is transitioning return
        UnloadCurrentZone();
        LoadZoneAtSpawnPoint(zoneData, spawnPointId);
    }
}
