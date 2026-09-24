using System.Collections.Generic;

public static class PersistenceParser 
{
    public static List<SerializableKeyValue<TKey, TValue>> ParseDict<TKey, TValue>(Dictionary<TKey, TValue> dict) =>
        ParseKeyValuePairs(dict, dict.Count);

    public static List<SerializableKeyValue<TKey, TValue>> ParseIReadOnlyDict<TKey, TValue>(IReadOnlyDictionary<TKey, TValue> dict) =>
        ParseKeyValuePairs(dict, dict.Count);

    public static List<T> ParseHashSet<T>(HashSet<T> hashSet)
    {
        var list = new List<T>(hashSet.Count);
        foreach (var hash in hashSet) 
            list.Add(hash);
        return list;
    }

    private static List<SerializableKeyValue<TKey, TValue>> ParseKeyValuePairs<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> source, int count) 
    {
        var list = new List<SerializableKeyValue<TKey, TValue>>(count);
        foreach (var kvp in source)
            list.Add(new SerializableKeyValue<TKey, TValue>
            {
                Key = kvp.Key,
                Val = kvp.Value
            });
        return list;
    }
}
