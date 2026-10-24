using UnityEngine;

public class WorldManagerComponentSpawn
{
    private WorldConfig config;
    private SpawnPointRegistry spawnPointRegistry;
    private StoryManager storyManager;

    public WorldManagerComponentSpawn(WorldConfig config, SpawnPointRegistry spawnPointRegistry, StoryManager storyManager)
    {
        this.config = config;
        this.spawnPointRegistry = spawnPointRegistry;
        this.storyManager = storyManager;
        SetWorldSpawn();
    }

    public void SetWorldSpawn() 
    {
        if (DebugUtils.IsDevBuild && config.IsDebugWorldEnabled)
            HandleSpawnDebug();
        else
            HandleSpawnStory();
    }


    private void HandleSpawnDebug()
    {
        WorldArgs.ZoneId = config.ZoneDataDebug.ZoneId;
        WorldArgs.CharacterPosition = Vector3.zero;
        WorldArgs.CharacterFacingDirection = Aremoreno.Enums.Animation.CharacterDirection.Down;
    }

    private void HandleSpawnStory()
    {
        if (storyManager.Flags.Get("game_new"))
        {
            WorldArgs.SetFromSpawnPoint(spawnPointRegistry.Get(config.SpawnPointIdDefault));
            storyManager.Flags.Set("game_new", false);
        }

        /* 
        else if (flag_last_check_point) 
        {
            // get from check point manager
        }
        */
    }
}
    
