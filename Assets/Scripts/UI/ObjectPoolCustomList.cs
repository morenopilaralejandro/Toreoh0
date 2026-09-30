using System;
using System.Collections.Generic;

public class ObjectPoolCustomList<T> : ObjectPoolCustom<T> 
{
    private readonly List<T> list = new ();
    public List<T> ActiveElements => list;

    public ObjectPoolCustomList(
        Func<T> createFunc,
        Action<T> actionOnGet,
        Action<T> actionOnRelease,
        Action<T> actionOnDestroy,
        int defaultCapacity
    ) : base(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, defaultCapacity) { }

    public override int CountActive => list.Count;
    public override int CountAll => CountActive + base.CountInactive;

    public override T Get() 
    {
        var element = base.Get();
        list.Add(element);
        return element;
    }

    public override void Release(T element)
    {
        base.Release(element);
        list.Remove(element);
    }

    public override void Dispose() 
    {
        foreach(var element in list)
            Release(element);
    }

    public override void Clear() => Dispose();

}
