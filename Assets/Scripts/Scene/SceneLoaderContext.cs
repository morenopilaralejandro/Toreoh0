using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SceneLoaderContext 
{
    public string Id;
    public IEnumerable<string> ScenesToLoad { get; private set; }
    public IEnumerable<string> ScenesToUnload { get; private set; }

    private ISceneLoaderOperations operations;
    private string loadingScreenSceneName;

    public SceneLoaderContext(
        string id,
        IEnumerable<string> scenesToLoad,
        IEnumerable<string> scenesToUnload,
        ISceneLoaderOperations operations,
        string loadingScreenSceneName = "SceneLoadingScreen")
    {
        this.Id = id;
        ScenesToLoad = scenesToLoad;
        ScenesToUnload = scenesToUnload;
        this.operations = operations;
        this.loadingScreenSceneName = loadingScreenSceneName;
    }

    public IEnumerator LoadScenes()
    {
        foreach (var scene in ScenesToLoad) 
            yield return operations.Load(scene);
    }

    public IEnumerator UnloadScenes() 
    {
        foreach (var scene in ScenesToUnload ?? new List<string>()) 
            yield return operations.Unload(scene);
    }

    public IEnumerator UnloadAll()
    {
        yield return operations.UnloadAll();
    }

    public IEnumerator LoadLoadingScreen()
    {
        yield return operations.Load(loadingScreenSceneName);
    }

    public IEnumerator UnloadLoadingScreen()
    {
        yield return operations.Unload(loadingScreenSceneName);
    }

    public bool HasSceneToUnload => ScenesToUnload != null && ScenesToUnload.Count() > 0;
}
