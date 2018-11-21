using System.IO;

namespace FileReader.Readers
{
    public class TextReader : IReader
    {
        public bool CanReadFileType(string filetype)
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
