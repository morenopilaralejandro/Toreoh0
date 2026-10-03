using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

public class WorldSceneLoader
{
    private SceneLoader sceneLoader;

    private void Initialize() 
    {
        ISceneLoaderRegistry registry = new SceneLoaderRegistry();
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

        await ExecuteLoad(context);
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

        await ExecuteUnload(context);
    }

    public async Task UnloadAll() 
    {
        SceneLoaderContext context = new SceneLoaderContext(
            "UnloadAll",
            null,
            null,
            sceneLoader.Operations
        );

        await ExecuteUnloadAll();
    }

    // Execute
    private async Task ExecuteLoad(SceneLoaderContext context)
    {
        yield return sceneLoader.Strategy.Load(context);
    }

    private async Task ExecuteUnload(SceneLoaderContext context)
    {
        yield return context.UnloadScenes();
    }

    private async Task ExecuteUnloadAll(SceneLoaderContext context)
    {
        yield return context.UnloadAll();
    }
}
