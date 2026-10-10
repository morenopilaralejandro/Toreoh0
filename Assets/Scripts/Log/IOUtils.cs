using UnityEngine;
using System.IO;

public static class IOUtils 
{
    public static string PathCombine(string path0, string path1) 
    {
        return Path.Combine(path0, path1);
    }

    public static string PathCombinePersistent(string path) 
    {
        return Path.Combine(Application.persistentDataPath, path);
    }

    public static void CreateDirectory(string path)
    {
        if(!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }
}
