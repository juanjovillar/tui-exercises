using System.IO;

namespace FileReader.Readers
{
    public class TextReader : IReader
    {
       public string Read(string filePath)
        {
            var content = File.ReadAllText(filePath);
            return content;
        }
    }
}
