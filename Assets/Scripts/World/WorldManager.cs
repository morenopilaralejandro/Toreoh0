using UnityEngine;
using System.Threading.Tasks;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance { get; private set; }

    [SerializeField] private WorldConfig config;
    [SerializeField] private FadeScreen worldFadeScreen;
    [SerializeField] public SpawnPointRegistry SpawnPointRegistry;
    [SerializeField] public CharacterEntityWorld CharacterMain;

    public WorldComponentStateMachine StateMachine { get; private set; }
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

    private void OnDestroy()
    {
        _ = sceneLoader.UnloadAll();
    }

    private void Update() 
    {
        chunkStreaming.Update();
    }

    private void Initialize()
    {
        SpawnPointRegistry.Initialize();

        worldFadeScreen.Initialize(SceneLoaderManager.Instance);

        StateMachine = new WorldComponentStateMachine();

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
            SpawnPointRegistry,
            StateMachine,
            worldFadeScreen
        );

        WorldArgs.ZoneId = "zone_interior_test_f0";
        WorldArgs.CharacterPosition = new Vector3(0f, 0f, 0f);
        WorldArgs.CharacterFacingDirection = Aremoreno.Enums.Animation.CharacterDirection.Down;

        InitializeAsync();
    }

    public async void InitializeAsync() 
    {
        await ZoneLoader.LoadZoneFromUnloaded();
    }
}
