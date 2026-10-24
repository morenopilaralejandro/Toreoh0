using UnityEngine;

public class FileWriterJson
{
    private string pathUncompressed;
    private string pathCompressed;
    private bool isCompressionEnabled;
    private bool isPrettyPrint;
    private IFileValidator validator;

    public string PathUncompressed => pathUncompressed;
    public string PathCompressed => pathCompressed;

    public FileWriterJson(
        string pathFolder, 
        string pathFileName,
        IFileValidator validator,
        bool isCompressionEnabled = false,
        bool isPrettyPrint = true,
        string extensionUncompressed = "json", 
        string extensionCompressed = "gz")
    {
        this.isCompressionEnabled = isCompressionEnabled;
        this.isPrettyPrint = isPrettyPrint;
        this.validator = validator;

        string pathFileNameUncompressed = $"{pathFileName}.{extensionUncompressed}";
        string pathFileNameCompressed = $"{pathFileName}.{extensionCompressed}";

        IOUtils.CreateDirectory(pathFolder);
        pathUncompressed = IOUtils.PathCombine(pathFolder, pathFileNameUncompressed);
        pathCompressed = IOUtils.PathCombine(pathFolder, pathFileNameCompressed);
    }

    // helper
    private bool IsValid(object obj) 
    {
        validator.SetData(obj);
        return validator.IsValid();
    }

    // write and read

    public void WriteAllJson(object obj)
    {
        IOUtils.WriteAllJson(pathUncompressed, obj, isPrettyPrint);
    }

    public T ReadAllJson<T>() 
    {
        return IOUtils.ReadAllJson<T>(pathUncompressed);
    }

    public void Write(object obj, bool isCheckValid = true, bool isDelete = true) 
    {
        if (isCheckValid && !IsValid(obj)) return;

        WriteAllJson(obj);
        if (!isCompressionEnabled) return;
        FileCompressor.Compress(pathUncompressed, pathCompressed);
        Compress(isDelete);
    }

    public T Read<T>(bool isCheckValid = true, bool isDelete = false) 
    {
        T obj = default;

        if (isCompressionEnabled)
        {
            if (!IOUtils.IsExistingFile(pathCompressed)) return default;
            Decompress(isDelete);
        }

        obj = ReadAllJson<T>();
        if (isCheckValid && !IsValid(obj as object)) return default;
        return obj;
    }

    // compress
    public void Compress(bool isDelete = true) 
    {
        if (!IOUtils.IsExistingFile(pathUncompressed)) return;
        FileCompressor.Compress(pathUncompressed, pathCompressed);
        if (isDelete) IOUtils.Delete(pathUncompressed);
    }

    public void Decompress(bool isDelete = false) 
    {
        if (!IOUtils.IsExistingFile(pathCompressed)) return;
        FileCompressor.Decompress(pathCompressed, pathUncompressed);
        if (isDelete) IOUtils.Delete(pathCompressed);
    }
}
