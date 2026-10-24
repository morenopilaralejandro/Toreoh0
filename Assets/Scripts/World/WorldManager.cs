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
    public WorldZoneTracker ZoneTracker;
    private WorldChunkStreaming chunkStreaming;
    private WorldSceneLoader sceneLoader;
    private WorldManagerComponentSpawn SpawnComponent;

    private void Awake() 
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        // DontDestroyOnLoad(gameObject);

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
        if (DatabaseManager.Instance == null) return;

        SpawnPointRegistry.Initialize();

        worldFadeScreen.Initialize(SceneLoaderManager.Instance);

        StateMachine = new WorldComponentStateMachine();

        ZoneTracker = new WorldZoneTracker(AudioManager.Instance);

        sceneLoader = new WorldSceneLoader(SceneLoaderManager.Instance);

        chunkStreaming = new WorldChunkStreaming(
            CharacterMain,
            sceneLoader,
            ZoneTracker
        );

        ZoneLoader = new WorldZoneLoader(
            DatabaseManager.Instance, 
            CharacterMain, 
            chunkStreaming, 
            sceneLoader, 
            ZoneTracker, 
            SpawnPointRegistry,
            StateMachine,
            worldFadeScreen
        );

        SpawnComponent = new WorldManagerComponentSpawn(config, SpawnPointRegistry, StoryManager.Instance);

        InitializeAsync();
    }

    public async void InitializeAsync() 
    {
        await ZoneLoader.LoadZoneFromUnloaded();
    }

    private void HandleWorldLoad()
    {
        if (DebugUtils.IsDevBuild && config.IsDebugWorldEnabled)
            HandleWorldLoadDebug();
        else
            HandleWorldLoadStory();
    }

    private void HandleWorldLoadDebug()
    {
        WorldArgs.ZoneId = config.ZoneDataDebug.ZoneId;
        WorldArgs.CharacterPosition = Vector3.zero;
        WorldArgs.CharacterFacingDirection = Aremoreno.Enums.Animation.CharacterDirection.Down;
    }

    private void HandleWorldLoadStory()
    {
        // TODO evaluate flags to set the world args
        /*
        WorldArgs.ZoneId = "zone_overworld_village";
        WorldArgs.CharacterPosition = Vector3.zero;
        WorldArgs.CharacterFacingDirection = Aremoreno.Enums.Animation.CharacterDirection.Down;
        */
    }
}
