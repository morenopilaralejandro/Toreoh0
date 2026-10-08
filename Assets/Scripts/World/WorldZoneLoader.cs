using UnityEngine;
using System.Threading.Tasks;
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
    private WorldComponentStateMachine stateMachine;
    private FadeScreen fadeScreen;

    public WorldZoneLoader(
        DatabaseManager databaseManager, 
        CharacterEntityWorld character, 
        WorldChunkStreaming chunkStreaming, 
        WorldSceneLoader sceneLoader, 
        WorldZoneTracker zoneTracker, 
        SpawnPointRegistry spawnPointRegistry,
        WorldComponentStateMachine stateMachine,
        FadeScreen fadeScreen)
    {
        this.databaseManager = databaseManager;
        this.character = character;
        this.chunkStreaming = chunkStreaming;
        this.sceneLoader = sceneLoader;
        this.zoneTracker = zoneTracker;
        this.spawnPointRegistry = spawnPointRegistry;
        this.stateMachine = stateMachine;   
        this.fadeScreen = fadeScreen;
    }

    // position
    private async Task LoadZoneAtPosition(ZoneData zoneData, Vector3 pos, CharacterDirection facingDirection)
    {
        if (zoneData.ZoneType == ZoneType.Overworld)
            await LoadZoneAtPositionOverworld(zoneData, pos, facingDirection);
        else
            await LoadZoneAtPositionInterior(zoneData, pos, facingDirection);
        zoneTracker.SetZone(zoneData);
    }

    private async Task LoadZoneAtPositionOverworld(ZoneData zoneData, Vector3 pos, CharacterDirection facingDirection) 
    {
        SetCharacter(pos, facingDirection);
        await chunkStreaming.StartStreaming(zoneData.OverworldData);
        // state in overworld
    }

    private async Task LoadZoneAtPositionInterior(ZoneData zoneData, Vector3 pos, CharacterDirection facingDirection)
    {
        await sceneLoader.LoadScenes(new string[] { zoneData.SceneAddressInterior });
        SetCharacter(pos, facingDirection);
        // state in interior
    }

    // SpawnPoint
    private async Task LoadZoneAtSpawnPoint(string spawnPointId)
    {
        SpawnPoint spawnPoint = spawnPointRegistry.Get(spawnPointId); 
        await LoadZoneAtPosition(
            databaseManager.DatabaseRegistry.ZoneData.Get(spawnPoint.ZoneId), 
            spawnPoint.SpawnPosition, 
            spawnPoint.FacingDirection);
    }

    // Unload
    public async Task UnloadCurrentZone() 
    {
        chunkStreaming.StopStreaming();
        await sceneLoader.UnloadAll();
    }

    // helper
    private void SetCharacter(Vector3 pos, CharacterDirection facingDirection) 
    {
        character.Teleport(pos);
        character.SetFacing(facingDirection);
    }

    // api
    public async Task LoadZoneFromUnloaded()
    {
        // state transitioning
        stateMachine.SetState(WorldState.Processing);
        await LoadZoneAtPosition(
            databaseManager.DatabaseRegistry.ZoneData.Get(WorldArgs.ZoneId),
            WorldArgs.CharacterPosition,
            WorldArgs.CharacterFacingDirection);
        await fadeScreen.FadeOut();
        stateMachine.SetState(WorldState.Idle);
    }

    public async void TransitionToZone(string spawnPointId)
    {
        // if state is transitioning return
        stateMachine.SetState(WorldState.Processing);
        await fadeScreen.FadeIn();
        await UnloadCurrentZone();
        await LoadZoneAtSpawnPoint(spawnPointId);
        await fadeScreen.FadeOut();
        stateMachine.SetState(WorldState.Idle);
    }
}
