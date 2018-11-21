using FileReader.Readers;
using System.IO;
using FileReader.Cryptography.Decrypters;
using FileReader.Security;

namespace FileReader.FileReaders
{
    public class XMLFileReader : FileReader
    {
        private readonly IReader _reader;
        private readonly IDecrypter _decrypter;
        private readonly ISecurityContext _securityContext;

        public XMLFileReader(
            IReader reader, 
            IDecrypter decrypter, 
            ISecurityContext securityContext)
        {
            _reader = reader;
            _decrypter = decrypter;
            _securityContext = securityContext;
        }

        public override bool CanManageType(string filetype)
        {
            return filetype == ".xml";
        }

        public override string Read(FileReadRequest request)
        {
            var file = new FileInfo(request.FilePath);
            var absoluteFilePath = GetAbsolutePath(file);

            if (!_securityContext.ValidateRequest(request))
            {
                return "ERROR - You don't have permission to access this file";
            }

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

