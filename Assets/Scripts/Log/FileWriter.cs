using UnityEngine;
using System.IO;

public class FileWriter
{
    private StreamWriter streamWriter;
    private string path;

    public void Initialize(string path)
    {
        this.path = Path.Combine(Application.persistentDataPath, path);
        streamWriter = new StreamWriter(path, true) { AutoFlush = true };
    }

    public void WriteToFile(string message) 
    {
        streamWriter.WriteLine(message);
    }

    public void Disable() 
    {
        if (streamWriter == null) return;
        streamWriter.Close();
        streamWriter.Dispose();
        streamWriter = null;
    }
}
