using UnityEngine;
using System.Collections;

public class SceneLoaderManager : MonoBehaviour
{
    // Fields
    public static SceneLoaderManager Instance { get; private set; }
        
    private SceneLoader sceneLoader;

    // Lifecycle
    private void Awake() 
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ISceneLoaderRegistry registry = new SceneLoaderRegistryGroup();
        sceneLoader = new SceneLoader(
            registry,
            new SceneLoaderOperationsDefault(registry),
            InputManager.Instance,
            DatabaseManager.Instance
        );
    }

    // Load by data
    private void LoadGroup(SceneGroupData sceneGroupData) 
    {
        sceneLoader.Strategy = sceneGroupData.HasLoadingScreen 
            ? new SceneLoaderStrategyLoadingScreen()
            : new SceneLoaderStrategyDirect();

        SceneLoaderContext context = new SceneLoaderContext(
            id : sceneGroupData.SceneGroupId,
            scenesToLoad : sceneGroupData.GetValidScenes(),
            scenesToUnload : null,
            operations : sceneLoader.Operations
        );

        StartCoroutine(ExecuteLoad(context));
    }

    private void UnloadGroup(SceneGroupData sceneGroupData)
    {
        SceneLoaderContext context = new SceneLoaderContext(
            sceneGroupData.SceneGroupId,
            null,
            sceneGroupData.GetValidScenes(),
            sceneLoader.Operations
        );

        StartCoroutine(ExecuteUnload(context));
    }

    // Load by id
    public void LoadGroup(string sceneGroupId) => LoadGroup(sceneLoader.DatabaseManager.DatabaseRegistry.SceneGroupData.Get(sceneGroupId));
    public void UnloadGroupGroup(string sceneGroupId) => UnloadGroup(sceneLoader.DatabaseManager.DatabaseRegistry.SceneGroupData.Get(sceneGroupId));

    // Coroutines
    private IEnumerator ExecuteLoad(SceneLoaderContext context)
    {
        sceneLoader.InputManager.Locker.Lock();
        yield return sceneLoader.Strategy.Load(context);
        sceneLoader.InputManager.Locker.Unlock();
    }

    private IEnumerator ExecuteUnload(SceneLoaderContext context)
    {
        yield return context.UnloadScenes();
    }
}
