using FileReader.Security;

namespace FileReader
{
    public class FileReadRequest
    {
        public FileReadRequest(string filePath, bool shouldDecrypt, Roles role)
        {
            FilePath = filePath;
            ShouldDecrypt = shouldDecrypt;
            UserRole = role;
        }

        public string FilePath { get; }

        public bool ShouldDecrypt { get; }

        public Roles UserRole { get; }
    }
}
