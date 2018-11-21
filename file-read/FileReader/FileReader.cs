using System.IO;
using System.Reflection;

namespace FileReader
{
    public abstract class FileReader
    {
        public abstract string Read(FileReadRequest request);

        public abstract bool CanManageType(string filetype);

        public string GetAbsolutePath(FileInfo fileInfo)
        {
            var baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(baseDir, fileInfo.FullName);

            return filePath;
        }
    }
}