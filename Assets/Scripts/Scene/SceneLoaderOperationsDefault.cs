using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;

public class SceneLoaderOperationsDefault : ISceneLoaderOperations
{
    private ISceneLoaderRegistry registry;

    public SceneLoaderOperationsDefault(ISceneLoaderRegistry registry)
    {
        this.registry = registry;
    }

    public IEnumerator Load(string sceneName) 
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!operation.isDone) yield return null;
        registry.Register(sceneName);
    }

    public IEnumerator Unload(string sceneName) 
    {
        AsyncOperation operation = SceneManager.UnloadSceneAsync(sceneName);
        while (!operation.isDone)  yield return null;
        registry.Unregister(sceneName);
    }

    private IEnumerator AwaitSceneObjectLoaders(string sceneName) 
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
