using System;
using System.Collections.Generic;

public abstract class ObjectPoolCustom<T> : IObjectPoolCustom<T>
{
    protected readonly Queue<T> queue = new();

    protected Func<T> createFunc;
    protected Action<T> actionOnGet;
    protected Action<T> actionOnRelease;
    protected Action<T> actionOnDestroy;
    protected int defaultCapacity;

    public virtual int CountActive => -1;
    public virtual int CountAll => queue.Count;
    public int CountInactive => queue.Count;

    protected ObjectPoolCustom(
        Func<T> createFunc,
        Action<T> actionOnGet,
        Action<T> actionOnRelease,
        Action<T> actionOnDestroy,
        int defaultCapacity
    ) 
    {
        this.createFunc = createFunc;
        this.actionOnGet = actionOnGet;
        this.actionOnRelease = actionOnRelease;
        this.actionOnDestroy = actionOnDestroy;
        this.defaultCapacity = defaultCapacity;

        Prewarm();
    }

    public virtual T Get() 
    {
        T element = queue.Count > 0 
            ? element = queue.Dequeue() 
            : element = createFunc.Invoke();
        actionOnGet?.Invoke(element);
        return element;
    }

    public virtual void Release(T element)
    {
        actionOnRelease?.Invoke(element);
        queue.Enqueue(element);
    }

    public virtual void Dispose() => Clear();

    public virtual void Clear() 
    {
        foreach (var element in queue)
        {
            if (element != null) actionOnDestroy.Invoke(element);
        }
        queue.Clear();
    }

    protected void Prewarm() 
    {
        for (int i = 0; i < defaultCapacity; i++) 
        {
            var element = createFunc.Invoke();
            queue.Enqueue(element);
        }
    }
}
