using UnityEngine;
using System.Collections;

public class SceneLoaderStrategyLoadingScreen : ISceneLoaderStrategy
{
    public IEnumerator Load(SceneLoaderContext context)
    {
        yield return context.LoadLoadingScreen();
        yield return new WaitForEndOfFrame();
        if (context.HasSceneToUnload) yield return context.UnloadScenes();
        yield return context.LoadScenes();
        yield return context.UnloadLoadingScreen();
    }
}
