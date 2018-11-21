using System.Xml.Linq;

namespace FileReader.Readers
{
    public class XMLReader : IReader
    {
        public bool CanReadFileType(string filetype)
        {
            return filetype == ".xml";
        }

        public string Read(string filePath)
        {
            var xmlContent = XElement.Load(filePath);
            return xmlContent.ToString();
        }
    }
}
