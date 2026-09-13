using System.Collections.Generic;

public class SceneLoaderRegistryGroup : ISceneLoaderRegistry
{
    private HashSet<string> loadedScenes = new HashSet<string>();

    public void Register(string sceneName) => loadedScenes.Add(sceneName);
    public void Unregister(string sceneName) => loadedScenes.Remove(sceneName);
    public bool IsLoaded(string sceneName) => loadedScenes.Contains(sceneName);
}
