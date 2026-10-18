using System.Collections.Generic;
using Aremoreno.Enums.Scene;

public interface ISceneLoaderRegistry 
{
    void SetState(string sceneName, SceneState state);
    bool IsLoaded(string sceneName);
    bool IsLoading(string sceneName);
    bool IsUnloaded(string sceneName);
    bool IsUnloading(string sceneName);
    List<string> GetScenesToUnload();

    void AddSceneData<T>(string sceneName, T data);
    T GetSceneData<T>(string sceneName);
    void RemoveSceneData(string sceneName);

    void Clear();
}
