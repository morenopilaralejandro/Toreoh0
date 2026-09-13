public interface ISceneLoaderRegistry 
{
    void Register(string sceneName);
    void Unregister(string sceneName);
    bool IsLoaded(string sceneName);
}
