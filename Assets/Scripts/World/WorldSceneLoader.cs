using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

public class WorldSceneLoader
{
    private SceneLoaderManager sceneLoaderManager;
    private SceneLoader sceneLoader;

    private void Initialize(SceneLoaderManager sceneLoaderManager) 
    {
        this.sceneLoaderManager = sceneLoaderManager;
        ISceneLoaderRegistry registry = new SceneLoaderRegistryAddressable();
        sceneLoader = new SceneLoader(
            registry,
            new SceneLoaderOperationsAddressable(registry),
            InputManager.Instance,
            DatabaseManager.Instance
        );
    }

    public async Task LoadScenes(IEnumerable<string> scenes, bool isFadeOut = false) 
    {
        /*
        sceneLoader.Strategy = isFadeOut
            ? new SceneLoaderStrategyFadeOut()
            : new SceneLoaderStrategyDirect();
        */

        sceneLoader.Strategy = new SceneLoaderStrategyDirect();

        SceneLoaderContext context = new SceneLoaderContext(
            id : scenes.GetHashCode().ToString(),
            scenesToLoad : scenes,
            scenesToUnload : null,
            operations : sceneLoader.Operations
        );

        await sceneLoaderManager.StartCoroutineAsync(ExecuteLoad(context));
    }

    public async Task UnloadScenes(IEnumerable<string> scenes, bool isFadeIn = false)
    {
        /*
        sceneLoader.Strategy = isFadeIn
            ? new SceneLoaderStrategyFadeIn()
            : new SceneLoaderStrategyDirect();
        */

        sceneLoader.Strategy = new SceneLoaderStrategyDirect();

        SceneLoaderContext context = new SceneLoaderContext(
            scenes.GetHashCode().ToString(),
            null,
            scenes,
            sceneLoader.Operations
        );

        await sceneLoaderManager.StartCoroutineAsync(ExecuteUnload(context));
    }

    public async Task UnloadAll() 
    {
        SceneLoaderContext context = new SceneLoaderContext(
            "UnloadAll",
            null,
            null,
            sceneLoader.Operations
        );

        await sceneLoaderManager.StartCoroutineAsync(ExecuteUnloadAll(context));
    }

    // Execute
    private IEnumerator ExecuteLoad(SceneLoaderContext context)
    {
        yield return sceneLoader.Strategy.Load(context);
    }

    private IEnumerator ExecuteUnload(SceneLoaderContext context)
    {
        yield return context.UnloadScenes();
    }

    private IEnumerator ExecuteUnloadAll(SceneLoaderContext context)
    {
        yield return context.UnloadAll();
    }
}
