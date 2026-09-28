public abstract class ObjectPoolCustomListWrapper<T> : MonoBehaviour 
{
    public ObjectPoolCustomList<T> Pool { get; private set; }

    public ObjectPoolCustomListWrapper(int defaultCapacity) 
    {
        Pool = new ObjectPoolCustomList<T>(CreateElement,OnGetElement,OnReturnElement,OnDestroyElement,defaultCapacity);
    }

    protected abstract T CreateElement();
    protected abstract T OnGetElement();
    protected abstract void OnReturnElement(T element);
    protected abstract void OnDestroyElement(T element);
}
