using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CacheLruAudioClip
{
    private readonly int capacity;
    private readonly Dictionary<string, LinkedListNode<CacheAudioClipKeyValue>> map;
    private readonly LinkedList<CacheAudioClipKeyValue> list;

    public CacheLruAudioClip(int capacity) 
    {
        this.capacity = capacity;
        map = new Dictionary<string, LinkedListNode<CacheAudioClipKeyValue>>(capacity);
        list = new LinkedList<CacheAudioClipKeyValue>();
    }

    public bool TryGet(string key, out AudioClip val)
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

    public void Add(string key, AudioClip val) 
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

        var newCacheAudioClipKeyValue = new CacheAudioClipKeyValue { Key = key, Val = val };
        var newNode = new LinkedListNode<CacheAudioClipKeyValue>(newCacheAudioClipKeyValue);
        list.AddFirst(newNode);
        map[key] = newNode;
    }

    public bool Remove(string key) 
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

    public IEnumerable<AudioClip> Values => map.Values.Select(n => n.Value.Val);
    public IEnumerable<string> Keys => map.Values.Select(n => n.Value.Key);
}
