using UnityEngine;
using System.IO;

public class FileWriter
{
    private StreamWriter streamWriter;

    public FileWriter(string pathFolder, string pathFileName)
    {
        IOUtils.CreateDirectory(pathFolder);
        string pathFull = IOUtils.PathCombine(pathFolder, pathFileName);
        streamWriter = new StreamWriter(pathFull, true) { AutoFlush = true };
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
