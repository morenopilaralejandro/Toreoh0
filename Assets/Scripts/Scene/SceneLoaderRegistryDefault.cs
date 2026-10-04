public class SceneLoaderRegistryDefault : SceneLoaderRegistry
{
    public override void AddSceneData<T>(string scene, T data) { }
    public override T GetSceneData<T>(string scene) { return default; }
    public override void RemoveSceneData(string scene) { }
}
