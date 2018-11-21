using FileReader.Readers;
using System.IO;
using FileReader.Cryptography.Decrypters;

namespace FileReader.FileReaders
{
    public class JsonFileReader : FileReader
    {
        private readonly IReader _reader;
        private readonly IDecrypter _decrypter;

        public JsonFileReader(IReader reader, IDecrypter decrypter)
        {
            _reader = reader;
            _decrypter = decrypter;
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

            if (request.ShouldDecrypt)
            {
                var decrypter = _decrypter;
                content = decrypter.Decrypt(content);
            }

            return content;
        }
    }
}

