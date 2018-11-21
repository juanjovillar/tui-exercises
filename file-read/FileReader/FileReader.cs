using System;
using System.IO;

namespace FileReader
{
    public class FileReader
    {
        public string Read(string filePath)
        {
            var content = File.ReadAllText(filePath);
            return content;
        }
    }
}
