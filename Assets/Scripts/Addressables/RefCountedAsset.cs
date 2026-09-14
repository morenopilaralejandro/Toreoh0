using UnityEngine.ResourceManagement.AsyncOperations;

public class RefCountedAsset
{
    public AsyncOperationHandle Handle;
    public int RefCount;
}
