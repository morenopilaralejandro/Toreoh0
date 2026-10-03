using System.Collections;

public interface ISceneLoaderOperations 
{
    public IEnumerator Load(string scene);
    public IEnumerator Unload(string scene);
    public IEnumerator UnloadAll();
}
