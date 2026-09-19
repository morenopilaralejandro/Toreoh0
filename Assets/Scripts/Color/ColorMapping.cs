using UnityEngine;

[System.Serializable]
public class ColorMapping<T> where T : System.Enum
{
    public T Key;
    public Color Color;
}
