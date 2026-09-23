using System.IO;
using System.IO.Compression;

public static class FileCompressor
{
    public static void Compress(string srcPath, string dstPath) 
    {
        using (FileStream srcStream =  new FileStream(srcPath, FileMode.Open))
            using (FileStream dstStream = new FileStream(dstPath, FileMode.Create))
                using (GzipStream gzipStream = new GzipStream(dstStream, CompressionMode.Compress))
                    srcStream.CopyTo(gzipStream);
    }

    public static void Decompress(string srcPath, string dstPath) 
    {
        using (FileStream srcStream = new FileStream(srcPath, FileMode.Open))
            using (FileStream dstStream = new FileStream(dstPath, FileMode.Create))
                using (GzipStream gzipStream = new GzipStream(dstStream, CompressionMode.Decompress))
                    gzipStream.CopyTo(dstStream);
    }
    

}
