using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;
using Aremoreno.Enums.Scene;

public class SceneLoaderOperationsDefault : SceneLoaderOperations
{
    public SceneLoaderOperationsDefault(ISceneLoaderRegistry registry) : base(registry) { }

    public override IEnumerator Load(string scene) 
    {
        base.Load(scene);
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        while (!operation.isDone) yield return null;
        yield return base.AwaitSceneObjectLoaders(scene);
        registry.SetState(scene, SceneState.Loaded);
    }

    public override IEnumerator Unload(string scene) 
    {
        base.Unload(scene);
        AsyncOperation operation = SceneManager.UnloadSceneAsync(scene);
        while (!operation.isDone) yield return null;
        registry.SetState(scene, SceneState.Unloaded);
    }
}
