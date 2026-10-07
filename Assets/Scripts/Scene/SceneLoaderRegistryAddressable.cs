using System.Collections.Generic;

public class SceneLoaderRegistryAddressable : SceneLoaderRegistry
{
    private Dictionary<string, object> dictData = new ();

    public override void AddSceneData<T>(string scene, T data) 
    {
        dictData[scene] = data;
    }

    public override T GetSceneData<T>(string scene)
    {
        if (dictData.TryGetValue(scene, out object data)) 
        {
            if (data is T castedData)
                return castedData;
        }
        return default;
    }

    public override void RemoveSceneData(string scene) 
    {
        if (dictData.TryGetValue(scene, out object data)) 
            dictData.Remove(scene);
    }

    public override void Clear()
    {
        base.Clear();
        dictData.Clear();
    }
}
