using FileReader.Readers;
using System.IO;
using FileReader.Security;

namespace FileReader.FileReaders
{
    public class XMLFileReader : FileReader
    {
        private readonly IReader _reader;
        private readonly ISecurityContext _securityContext;

        public XMLFileReader(IReader reader, ISecurityContext securityContext)
        {
            _reader = reader;
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

            if (_securityContext.ValidateRequest(request))
            {
                return _reader.Read(absoluteFilePath);
            }

            return "ERROR - You don't have permission to access this file";
        }
    }
}

