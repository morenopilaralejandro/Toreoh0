using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance { get; private set; }

    [SerializeField] private WorldConfig config;
    [SerializeField] public SpawnPointRegistry SpawnPointRegistry;

    public CharacterEntityWorld CharacterMain;
    public WorldZoneLoader ZoneLoader { get; private set; }
    private WorldZoneTracker zoneTracker;
    private WorldChunkStreaming chunkStreaming;
    private WorldSceneLoader sceneLoader;

    private void Awake() 
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        // DontDestroyOnLoad(gameObject);

        if (DatabaseManager.Instance == null) return;
        Initialize();
    }

    private void Initialize() 
    {
        SpawnPointRegistry.Initialize();

        zoneTracker = new WorldZoneTracker(AudioManager.Instance);

        sceneLoader = new WorldSceneLoader(SceneLoaderManager.Instance);

        chunkStreaming = new WorldChunkStreaming(
            CharacterMain,
            sceneLoader,
            zoneTracker
        );

        ZoneLoader = new WorldZoneLoader(
            DatabaseManager.Instance, 
            CharacterMain, 
            chunkStreaming, 
            sceneLoader, 
            zoneTracker, 
            SpawnPointRegistry
        );

        WorldArgs.ZoneId = "zone_interior_test_f0";
        WorldArgs.CharacterPosition = new Vector3(0f, 0f, 0f);
        WorldArgs.CharacterFacingDirection = Aremoreno.Enums.Animation.CharacterDirection.Down;

        ZoneLoader.LoadZoneFromUnloaded();
    }

    private void Update() 
    {
        chunkStreaming.Update();
    }
}
