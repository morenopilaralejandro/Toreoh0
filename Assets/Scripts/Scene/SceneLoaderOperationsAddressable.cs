using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Aremoreno.Enums.Scene;

public class SceneLoaderOperationsAddressable : SceneLoaderOperations
{
    public SceneLoaderOperationsAddressable(ISceneLoaderRegistry registry) : base(registry) { }

    public override IEnumerator Load(string scene) 
    {
        base.Load(scene);
        yield return LoadAsync(scene);
        registry.SetState(scene, SceneState.Loaded);
    }

    public override IEnumerator Unload(string scene) 
    {
        base.Unload(scene);
        yield return UnloadAsync(scene);
        registry.SetState(scene, SceneState.Unloaded);
    }

    private async Task LoadAsync(string scene) 
    {
        await Addressables.LoadSceneAsync(scene, LoadSceneMode.Additive, true).Task;
    }

    private async Task UnloadAsync(string scene) 
    {
        await Addressables.UnloadSceneAsync(scene).Task;
    }
}
