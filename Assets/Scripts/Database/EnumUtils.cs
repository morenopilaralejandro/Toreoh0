using System.Collections.Generic;

public static class EnumUtils
{
    public static T StringToEnum<T>(string stringValue, bool ignoreCase = true) where T : struct, System.Enum => System.Enum.Parse<T>(stringValue, ignoreCase);
    public static string EnumToString<T>(T enumValue) => enumValue.ToString();

    public static List<T> ParseEnumList<T>(string stringValue, char delimiter = '|') where T : struct, System.Enum
    {
        var list = new List<T>();
        if(string.IsNullOrEmpty(stringValue)) return list;
        string[] parts = stringValue.Split(delimiter);
        foreach (string part in parts)
            list.Add(StringToEnum<T>(stringValue));
        return list;
    }

    public static List<string> ParseStringList(string stringValue, char delimiter = '|')
    {
        var list = new List<string>();
        if(string.IsNullOrEmpty(stringValue)) return list;

        string[] parts = stringValue.Split(delimiter);
        foreach (string part in parts)
            list.Add(part.Trim());
        return list;
    }

    public static int GetLength<T>() where T : System.Enum => System.Enum.GetValues(typeof(T)).Length;
    public static T[] GetValues<T>() where T : System.Enum => (T[])System.Enum.GetValues(typeof(T));
    public static string[] GetNames<T>() where T : System.Enum => System.Enum.GetNames(typeof(T));

    public static string GetSafeEnumString(string stringValue) => stringValue
        .Replace('.', '_');
}
