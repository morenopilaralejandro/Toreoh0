public class ObjectPoolCustomList<T> : ObjectPoolCustom<T> 
{
    private readonly List<T> list = new ();
    public IReadOnlyList<T> ActiveElements => list;

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
