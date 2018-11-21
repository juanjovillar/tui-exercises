using System.IO;

namespace FileReader.Readers
{
    public class TextReader : IReader
    {
        public bool CanManageType(string filetype)
        {
            return filetype == ".txt";
        }

        public string Read(string filePath)
        {
            var content = File.ReadAllText(filePath);
            return content;
        }
    }
}
