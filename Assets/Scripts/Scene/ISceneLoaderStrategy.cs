using System.Collections;

public interface ISceneLoaderStrategy 
{
    IEnumerator Load(SceneLoaderContext context);
}
