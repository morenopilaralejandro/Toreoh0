using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ColorDictionary<T> : IColorDictionary where T : System.Enum
{
    [SerializeField] private List<ColorMapping<T>> list;
    private readonly Dictionary<T, Color> data = new();
    public IReadOnlyDictionary<T, Color> Data => data;

    public void Initialize()
    {
        foreach(var mapping in list)
             data[mapping.Key] = mapping.Color;
    }

    public Color Get(T id) => data[id];
}
