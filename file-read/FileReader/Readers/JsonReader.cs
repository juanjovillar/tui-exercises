using System.IO;

namespace FileReader.Readers
{
    public class JsonReader : IReader
    {
       public string Read(string filePath)
        {
            var content = File.ReadAllText(filePath);
            return content;
        }
    }
}
