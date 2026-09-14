using System.Collections.Generic;

public class CacheLru<TKey, TValue>
{
    private readonly int capacity;
    private readonly Dictionary<TKey, LinkedListNode<CacheKeyValue>> map;
    private readonly LinkedList<CacheKeyValue> list;

    private class CacheKeyValue
    {
        public TKey Key;
        public TValue Val;
    }

    public CacheLru(int capacity) 
    {
        this.capacity = capacity;
        map = new Dictionary<TKey, LinkedListNode<CacheKeyValue>>(capacity);
        list = new LinkedList<CacheKeyValue>();
    }

    public bool TryGet(TKey key, out TValue val)
    {
        if(map.TryGetValue(key, out var node))
        {
            val = node.Value.Val;
            list.Remove(node);
            list.AddFirst(node);
            return true;
        }

        val = default;
        return false;
    }

    public void Add(TKey key, TValue val) 
    {
        if(map.TryGetValue(key, out var node)) 
        {
            node.Value.Val = val;
            list.Remove(node);
            list.AddFirst(node);
            return;
        }

        if(map.Count >= capacity) 
        {
            map.Remove(list.Last.Value.Key);
            list.RemoveLast();
        }

        var newCacheKeyValue = new CacheKeyValue { Key = key, Val = val };
        var newNode = new LinkedListNode<CacheKeyValue>(newCacheKeyValue);
        list.AddFirst(newNode);
        map[key] = newNode;
    }

    public bool Remove(TKey key) 
    {
        if (map.TryGetValue(key, out var node))
        {
            map.Remove(key);
            list.Remove(node);
            return true;
        }

        return false;
    }

    public void Clear() 
    {
        map.Clear();
        list.Clear();
    }
}
