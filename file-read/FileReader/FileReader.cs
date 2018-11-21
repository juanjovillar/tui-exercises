using FileReader.Readers;
using System.IO;
using System.Reflection;
using FileReader.Cryptography;
using FileReader.Cryptography.Algorithms;
using FileReader.Cryptography.Decrypters;

namespace FileReader
{
    public class FileReader
    {
        private readonly ReadersFactory _readersFactory;
        private readonly DecryptersFactory _decryptersFactory;
        private readonly IAlgorithm _decryptionAlgorithm;

        public FileReader()
        {
            _readersFactory = new ReadersFactory();
            _decryptersFactory = new DecryptersFactory();
            _decryptionAlgorithm = new ReverseDecryptor();
        }

        public string Read(string filePath, bool shouldDecrypt)
        {
            var file = new FileInfo(filePath);
            var absoluteFilePath = GetAbsolutePath(file);

            var reader = _readersFactory.GetReader(file.Extension);
            var content = reader.Read(absoluteFilePath);

            if (shouldDecrypt)
            {
                var decrypter = _decryptersFactory.GetDecrypter(file.Extension);
                content = decrypter.Decrypt(_decryptionAlgorithm, content);
            }

            return content;
        }

        private string GetAbsolutePath(FileInfo fileInfo)
        {
            var baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(baseDir, fileInfo.FullName);

            return filePath;
        }
    }
}

