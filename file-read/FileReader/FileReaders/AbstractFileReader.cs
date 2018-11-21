using System.IO;
using System.Reflection;
using FileReader.Cryptography.Decrypters;
using FileReader.Readers;
using FileReader.Security;

namespace FileReader
{
    public abstract class AbstractFileReader
    {
        private readonly IReader _reader;
        private readonly ISecurityContext _securityContext;
        private readonly IDecrypter _decrypter;

        protected AbstractFileReader(
            IReader reader, 
            IDecrypter decrypter, 
            ISecurityContext securityContext)
        {
            _reader = reader;
            _securityContext = securityContext;
            _decrypter = decrypter;
        }

        public abstract bool CanManageType(string filetype);

        public virtual string Read(FileReadRequest request)
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

        public string GetAbsolutePath(FileInfo fileInfo)
        {
            var baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(baseDir, fileInfo.FullName);

            return filePath;
        }
    }
}