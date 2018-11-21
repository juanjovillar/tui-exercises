using FileReader.Cryptography.Decrypters;
using FileReader.Readers;
using System.IO;

namespace FileReader.FileReaders
{
    public class TextFileReader : FileReader
    {
        private readonly IReader _reader;
        private readonly IDecrypter _decrypter;

        public TextFileReader(IReader reader, IDecrypter decrypter)
        {
            _reader = reader;
            _decrypter = decrypter;
        }

        public override bool CanManageType(string filetype)
        {
            return filetype == ".txt";
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

