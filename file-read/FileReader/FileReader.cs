using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FileReader.Readers;
using TextReader = FileReader.Readers.TextReader;

namespace FileReader
{
    public class FileReader
    {
        private IEnumerable<IReader> Readers => new List<IReader>
        {
            new TextReader(),
            new XMLReader(),
        };

        public string Read(string filePath)
        {
            var file = new FileInfo(filePath);
            var absoluteFilePath = GetAbsolutePath(file);

            var reader = Readers.FirstOrDefault(x => x.CanReadFileType(file.Extension));
            if (reader == null)
            {
                throw new ArgumentException($"Cannot read files of type {file.Extension}");
            }

            return reader.Read(absoluteFilePath);
        }

        private string GetAbsolutePath(FileInfo fileInfo)
        {
            var baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(baseDir, fileInfo.FullName);

            return filePath;
        }
    }
}
