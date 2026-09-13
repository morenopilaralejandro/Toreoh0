using System.Collections;

public class SceneLoaderStrategyDirect : ISceneLoaderStrategy
{
    public IEnumerator Load(SceneLoaderContext context)
    {
        if (context.HasSceneToUnload) yield return context.UnloadScenes();
        yield return context.LoadScenes();
    }
}
