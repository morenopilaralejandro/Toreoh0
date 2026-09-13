using System.Collections;

public class SceneLoaderStrategyLoadingScreen : ISceneLoaderStrategy
{
    public IEnumerator Load(SceneLoaderContext context)
    {
        yield return context.LoadLoadingScreen();
        if (context.HasSceneToUnload) yield return context.UnloadScenes();
        yield return context.LoadScenes();
        yield return context.UnloadLoadingScreen();
    }
}
