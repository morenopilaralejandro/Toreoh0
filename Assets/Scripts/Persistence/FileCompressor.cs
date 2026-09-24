using System.IO;
using System.IO.Compression;

public static class FileCompressor
{
    public static void Compress(string srcPath, string dstPath) 
    {
        using (FileStream srcStream =  new FileStream(srcPath, FileMode.Open))
            using (FileStream dstStream = new FileStream(dstPath, FileMode.Create))
                using (GZipStream gZipStream = new GZipStream(dstStream, CompressionMode.Compress))
                    srcStream.CopyTo(gZipStream);
    }

    public static void Decompress(string srcPath, string dstPath) 
    {
        using (FileStream srcStream = new FileStream(srcPath, FileMode.Open))
            using (FileStream dstStream = new FileStream(dstPath, FileMode.Create))
                using (GZipStream gZipStream = new GZipStream(dstStream, CompressionMode.Decompress))
                    gZipStream.CopyTo(dstStream);
    }
    

}
