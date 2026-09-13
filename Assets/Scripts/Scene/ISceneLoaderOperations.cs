using System.Collections;

public interface ISceneLoaderOperations 
{
    public IEnumerator Load(string sceneName);
    public IEnumerator Unload(string sceneName);
}
