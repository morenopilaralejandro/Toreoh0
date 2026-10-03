using UnityEngine;

public class WorldSceneLoader : MonoBehaviour
{
    private SceneLoader sceneLoader;

    private void Initialize() 
    {
        ISceneLoaderRegistry registry = new SceneLoaderRegistryGroup();
        sceneLoader = new SceneLoader(
            registry,
            new SceneLoaderOperationsAddressable(registry),
            InputManager.Instance,
            DatabaseManager.Instance
        );
    }


    // TODO use new string[] { address } when calling and only use the one with enumerable
    // Load by data
    private void LoadScene(string address, isFade = false) 
    {
        sceneLoader.Strategy = isFade
            ? new SceneLoaderStrategyFade()
            : new SceneLoaderStrategyDirect();

        SceneLoaderContext context = new SceneLoaderContext(
            id : sceneGroupData.SceneGroupId,
            scenesToLoad : new string[] { address },
            scenesToUnload : null,
            operations : sceneLoader.Operations
        );

        StartCoroutine(ExecuteLoad(context));
    }

    private void LoadScenes(Enumaerable list, isFade = false)

    private void UnloadScene(string address)
    {
        SceneLoaderContext context = new SceneLoaderContext(
            sceneGroupData.SceneGroupId,
            null,
            new string[] { address },
            sceneLoader.Operations
        );

        StartCoroutine(ExecuteUnload(context));
    }

    private void UnloadScenes(list)

    private void UnloadAll() 
    {
        SceneLoaderContext context = new SceneLoaderContext(
            sceneGroupData.SceneGroupId,
            null,
            registry.GetLoadedScenes(),
            sceneLoader.Operations
        );

        StartCoroutine(ExecuteUnload(context));
    }

    // Coroutines
    private IEnumerator ExecuteLoad(SceneLoaderContext context)
    {
        yield return sceneLoader.Strategy.Load(context);
    }

    private IEnumerator ExecuteUnload(SceneLoaderContext context)
    {
        yield return context.UnloadScenes();
    }
}
