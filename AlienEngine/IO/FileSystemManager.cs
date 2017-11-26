using System.IO;
using System.Threading.Tasks;

namespace AlienEngine.Core.IO
{
    public static class FileSystemManager
    {

        public static string ReadFileAsString(string path)
        {
            return File.ReadAllText(path);
        }

        public static byte[] ReadFileAsBytes(string path)
        {
            return File.ReadAllBytes(path);
        }

        public static FileStream Read(string path)
        {
            return File.OpenRead(path);
        }

        public static async Task<string> AsyncReadFileAsString(string path)
        {
            return await Task.Run(() => ReadFileAsString(path));
        }

    }
}
