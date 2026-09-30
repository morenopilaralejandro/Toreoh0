using System;

public abstract class ObjectPoolCustomListWrapper<T> 
{
    public ObjectPoolCustomList<T> Pool { get; private set; }

    public virtual void Initialize(Action<T> actionOnGet, Action<T> actionOnRelease, int defaultCapacity) 
    {
        Pool = new ObjectPoolCustomList<T>(CreateElement, actionOnGet, actionOnRelease, OnDestroyElement, defaultCapacity);
    }

    protected abstract T CreateElement();
    protected abstract void OnDestroyElement(T element);
}
