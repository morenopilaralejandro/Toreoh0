using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;
using Aremoreno.Enums.Scene;

public abstract class SceneLoaderOperations : ISceneLoaderOperations
{
    protected ISceneLoaderRegistry registry;
    protected bool isUnloadingAll;

    public SceneLoaderOperations(ISceneLoaderRegistry registry)
    {
        isUnloadingAll = false;
        this.registry = registry;
    }

    public virtual IEnumerator Load(string scene) 
    {
        if (isUnloadingAll) yield break;
        if (registry.IsLoaded(scene)) yield break;
        registry.SetState(scene, SceneState.Loading);
    }

    public virtual IEnumerator Unload(string scene) 
    {
        while(registry.IsLoading(scene)) yield return null;
        if (!registry.IsLoaded(scene)) yield break;
        registry.SetState(scene, SceneState.Unloading);
    }

    public IEnumerator UnloadAll()
    {
        isUnloadingAll = true;
        foreach (var scene in registry.GetScenesToUnload())
            yield return Unload(scene);
        isUnloadingAll = false;
    }

    protected IEnumerator AwaitSceneObjectLoaders(string sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        var loaders = scene.GetRootGameObjects()
            .SelectMany(go => go.GetComponentsInChildren<IAsyncSceneLoader>())
            .ToList();

        if (loaders.Count > 0) 
        {
            var task = loaders.Select(l => l.LoadAsync()).ToList();
            while (task.Any(t => !t.IsCompleted)) yield return null;
        }
    }
}
