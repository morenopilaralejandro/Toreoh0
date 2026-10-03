using System.Collections.Generic;
using Aremoreno.Enums.Scene;

public class SceneLoaderRegistry : ISceneLoaderRegistry
{
    private Dictionary<string, SceneState> dictState;

    public void SetState(string scene, SceneState state)
    {
        if (state == SceneState.Unloaded)
            dictState.Remove(scene);
        else
            dictState[scene] = state;
    }

    private bool IsState(string scene, SceneState state, bool defaultValue) 
    {
        if (dictState.TryGetValue(scene, out var currentState))
            return currentState == state;
        else
            return defaultValue;
    }

    public bool IsLoaded(string scene) => IsState(scene, SceneState.Loaded, false);
    public bool IsLoading(string scene) => IsState(scene, SceneState.Loading, false);
    public bool IsUnloaded(string scene) => IsState(scene, SceneState.Unloaded, true);
    public bool IsUnloading(string scene) => IsState(scene, SceneState.Unloading, false);

    public List<string> GetScenesToUnload()
    {
        List<string> loadedScenes = new ();
        foreach (var kvp in dictState)
        {
            if (kvp.Value == SceneState.Loaded || kvp.Value == SceneState.Loading)
                loadedScenes.Add(kvp.Key);
        }
        return loadedScenes;
    }

    public void Clear() 
    {
        dictState.Clear();
    }
}
