using System.Collections;
using System.Collections.Generic;

public class SceneLoaderContext 
{
    public string Id;
    public IReadOnlyList<SceneData> ScenesToLoad { get; private set; }
    public IReadOnlyList<SceneData> ScenesToUnload { get; private set; }

    private ISceneLoaderOperations operations;
    private string loadingScreenSceneName;

    public SceneLoaderContext(
        string id,
        IReadOnlyList<SceneData> scenesToLoad,
        IReadOnlyList<SceneData> scenesToUnload,
        ISceneLoaderOperations operations,
        string loadingScreenSceneName = "LoadingScene") 
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
            yield return operations.Load(scene.SceneName);
    }

    public IEnumerator UnloadScenes() 
    {
        foreach (var scene in ScenesToUnload ?? new List<SceneData>()) 
            yield return operations.Load(scene.SceneName);
    }

    public IEnumerator LoadLoadingScreen()
    {
        yield return operations.Load(loadingScreenSceneName);
    }

    public IEnumerator UnloadLoadingScreen()
    {
        yield return operations.Unload(loadingScreenSceneName);
    }

    public bool HasSceneToUnload => ScenesToUnload != null && ScenesToUnload.Count > 0;
}
