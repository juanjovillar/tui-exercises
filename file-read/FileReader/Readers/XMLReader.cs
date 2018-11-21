using System.Xml.Linq;

namespace FileReader.Readers
{
    public class XMLReader : IReader
    {
       public string Read(string filePath)
        {
            var xmlContent = XElement.Load(filePath);
            return xmlContent.ToString();
        }
    }
}
