using UnityEngine;
using System.IO;
using System.Collections.Generic;

public static class IOUtils 
{
    // PathCombine
    public static string PathCombine(string path0, string path1) 
    {
        return Path.Combine(path0, path1);
    }

    public static string PathCombinePersistent(string path) 
    {
        return Path.Combine(Application.persistentDataPath, path);
    }

    // Exists
    public static void CreateDirectory(string path)
    {
        if(!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }

    public static bool IsExistingFile(string path) => File.Exists(path);

    // operation
    public static void Copy(string pathSrc, string pathDst, bool isOverwrite = true)
    {
        if(!IsExistingFile(pathSrc)) return;
        File.Copy(pathSrc, pathDst, isOverwrite);
    }

    public static void Delete(string path)
    {
        if(!IsExistingFile(path)) return;
        File.Delete(path);
    }

    // text
    public static void WriteAllText(string path, string text) 
    {
        File.WriteAllText(path, text);
    }

    public static string ReadAllText(string path)
    {
        if(!IsExistingFile(path)) return string.Empty;
        return File.ReadAllText(path);
    }

    // json
    public static string ToJson(object obj, bool isPrettyPrint = true) 
    {
        return JsonUtility.ToJson(obj, isPrettyPrint);
    }

    public static T FromJson<T>(string json)
    {
        return JsonUtility.FromJson<T>(json);
    }

    public static void WriteAllJson(string path, object obj, bool isPrettyPrint = true)
    {
        string json = ToJson(obj, isPrettyPrint);
        File.WriteAllText(path, json);
    }

    public static T ReadAllJson<T>(string path) 
    {
        string json = ReadAllText(path);
        if (string.IsNullOrEmpty(json)) return default;
        return JsonUtility.FromJson<T>(json);
    }
}
