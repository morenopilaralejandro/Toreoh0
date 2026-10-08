using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

public class WorldSceneLoader
{
    private SceneLoaderManager sceneLoaderManager;
    private SceneLoader sceneLoader;

    public WorldSceneLoader(SceneLoaderManager sceneLoaderManager) 
    {
        this.sceneLoaderManager = sceneLoaderManager;
        ISceneLoaderRegistry registry = new SceneLoaderRegistryAddressable();
        sceneLoader = new SceneLoader(
            registry,
            new SceneLoaderOperationsAddressable(registry),
            InputManager.Instance,
            DatabaseManager.Instance
        );
        sceneLoader.Strategy = new SceneLoaderStrategyDirect();
    }

    public async Task LoadScenes(IEnumerable<string> scenes)
    {
        SceneLoaderContext context = new SceneLoaderContext(
            id : scenes.GetHashCode().ToString(),
            scenesToLoad : scenes,
            scenesToUnload : null,
            operations : sceneLoader.Operations
        );

        await sceneLoaderManager.StartCoroutineAsync(ExecuteLoad(context));
    }

    public async Task UnloadScenes(IEnumerable<string> scenes)
    {
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
