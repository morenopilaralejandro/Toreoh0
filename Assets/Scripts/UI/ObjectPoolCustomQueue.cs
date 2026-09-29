using System;

public class ObjectPoolCustomQueue<T> : ObjectPoolCustom<T> 
{
    public ObjectPoolCustomQueue(
        Func<T> createFunc,
        Action<T> actionOnGet,
        Action<T> actionOnRelease,
        Action<T> actionOnDestroy,
        int defaultCapacity
    ) : base(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, defaultCapacity) { }
}
