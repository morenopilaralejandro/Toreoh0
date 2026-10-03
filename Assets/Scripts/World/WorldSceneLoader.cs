using UnityEngine;
using System.Collections;

public class WorldSceneLoader : MonoBehaviour
{
    private SceneLoader sceneLoader;

    private void Initialize() 
    {
        /*
        ISceneLoaderRegistry registry = new SceneLoaderRegistryGroup();
        sceneLoader = new SceneLoader(
            registry,
            new SceneLoaderOperationsAddressable(registry),
            InputManager.Instance,
            DatabaseManager.Instance
        );
        */
    }

    // TODO use new string[] { address } when calling and only use the one with enumerable
    // Load by data
    public void LoadScene(string scene, bool isFade = false)
    {
        /*
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
        */
    }

    public void LoadScenes(IEnumerable scenes, bool isFade = false) 
    {

    }

    public void UnloadScene(string scene)
    {
        /*
        SceneLoaderContext context = new SceneLoaderContext(
            sceneGroupData.SceneGroupId,
            null,
            new string[] { address },
            sceneLoader.Operations
        );

        StartCoroutine(ExecuteUnload(context));
        */
    }

    public void UnloadScenes(IEnumerable scenes, bool isFade = false)
    {

    }

    public void UnloadAll() 
    {
        /*
        SceneLoaderContext context = new SceneLoaderContext(
            sceneGroupData.SceneGroupId,
            null,
            registry.GetLoadedScenes(),
            sceneLoader.Operations
        );

        StartCoroutine(ExecuteUnload(context));
        */
    }

    // Coroutines
    /*
    private IEnumerator ExecuteLoad(SceneLoaderContext context)
    {
        yield return sceneLoader.Strategy.Load(context);
    }

    private IEnumerator ExecuteUnload(SceneLoaderContext context)
    {
        yield return context.UnloadScenes();
    }
    */
}
