using FileReader.Readers;
using System.IO;

namespace FileReader.FileReaders
{
    public class JsonFileReader : FileReader
    {
        private readonly IReader _reader;

        public JsonFileReader(IReader reader)
        {
            _reader = reader;
        }

        public override bool CanManageType(string filetype)
        {
            return filetype == ".json";
        }

        public override string Read(FileReadRequest request)
        {
            var file = new FileInfo(request.FilePath);
            var absoluteFilePath = GetAbsolutePath(file);

            var content = _reader.Read(absoluteFilePath);

            return content;
        }
    }
}

