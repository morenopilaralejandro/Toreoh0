using UnityEngine;
using System.Collections.Generic;

public class WorldChunkStreaming
{
    private CharacterEntityWorld character;
    private WorldSceneLoader sceneLoader;
    private WorldZoneTracker zoneTracker;

    private OverworldData overworldData;
    private bool isActive;
    private bool isUpdating;
    private float updateTimer;
    private float updateInterval;
    private float inverseChunkSize;
    private int radius;
    private Vector2Int lastCharacterChunkCoord;

    private readonly Dictionary<string, ChunkData> dictChunkData = new ();
    private readonly Dictionary<Vector2Int, ChunkData> dictChunkCoord = new ();
    private readonly HashSet<string> hashSetSceneLoaded = new ();
    private readonly HashSet<string> hashSetSceneDesired = new ();
    private readonly List<string> listScenePendingLoad = new ();
    private readonly List<string> listSetScenePendingUnload = new ();

    public void Initialize()
    {
        this.inverseChunkSize = 1f / WorldConstants.CHUCK_SIZE;
        this.radius = WorldConstants.CHUCK_STREAMING_RADIUS;
        this.updateInterval = WorldConstants.CHUCK_STREAMING_UPDATE_INTERVAL;
    }

    public void Update()
    {
        if (!isActive || overworldData == null) return;
        updateTimer += Time.deltaTime;
        if (updateTimer >= updateInterval)
            UpdateChunksAroundCharacter();
    }

    public void StartStreaming(OverworldData overworldData)
    {
        this.overworldData = overworldData;
        lastCharacterChunkCoord = new Vector2Int(int.MinValue, int.MinValue);   
        isActive = true;
        updateTimer = 0f;

        dictChunkData.Clear();
        dictChunkCoord.Clear();

        List<ChunkData> chunks = overworldData.Chunks;
        for (int i = 0, count = chunks.Count; i < count; i++)
        {
            ChunkData chunk = chunks[i];
            dictChunkData[chunk.ChunkId] = chunk;
            dictChunkCoord[chunk.ChunkCoord] = chunk;
        }

        UpdateChunksAroundCharacter();
    }

    public void StopStreaming() 
    {
        isActive = false;
        overworldData = null;
    }

    public void UpdateChunksAroundCharacter() 
    {
        updateTimer = 0;
        if (character == null) return;
        if (isUpdating) return;
        isUpdating = true;

        Vector3 pos = character.transform.position;
        int xCurrent = Mathf.FloorToInt(pos.x * inverseChunkSize);
        int yCurrent = Mathf.FloorToInt(pos.y * inverseChunkSize);
        if (xCurrent == lastCharacterChunkCoord.x && yCurrent == lastCharacterChunkCoord.y) return;
        lastCharacterChunkCoord.x = xCurrent;
        lastCharacterChunkCoord.y = yCurrent;
        zoneTracker.SetZone(dictChunkCoord[lastCharacterChunkCoord].ZoneData);

        // determine disired
        hashSetSceneDesired.Clear();
        for (int xDelta = -radius; xDelta <= radius; xDelta++) 
        {
            for (int yDelta = -radius; yDelta <= radius; yDelta++) 
            {
                Vector2Int calculatedChunkCoord = new Vector2Int(xCurrent + xDelta, yCurrent + yDelta);
                ChunkData chunk;
                if (dictChunkCoord.TryGetValue(calculatedChunkCoord, out chunk))
                    hashSetSceneDesired.Add(chunk.SceneAddressChunk);
            }
        }

        // determine unload
        listSetScenePendingUnload.Clear();
        foreach (string loaded in hashSetSceneLoaded)
        {
            if (!hashSetSceneDesired.Contains(loaded))
                listSetScenePendingUnload.Add(loaded);
        }

        // determine load
        listScenePendingLoad.Clear();
        foreach (string desired in hashSetSceneDesired) 
        {
            if (!hashSetSceneLoaded.Contains(desired))
                listScenePendingLoad.Add(desired); 
        }

        // perform unload
        foreach (string scene in listSetScenePendingUnload) 
            hashSetSceneLoaded.Remove(scene);
        sceneLoader.UnloadScenes(listSetScenePendingUnload);

        // perform load
        foreach (string scene in listScenePendingLoad) 
            hashSetSceneLoaded.Add(scene);
        sceneLoader.LoadScenes(listScenePendingLoad);

        isUpdating = false;
    }
}
