using FileReader.Cryptography.Decrypters;
using FileReader.Readers;
using FileReader.Security;

namespace FileReader.FileReaders
{
    public class XMLFileReader : AbstractFileReader
    {
        public XMLFileReader(
            IReader reader,
            IDecrypter decrypter,
            ISecurityContext securityContext)
            : base(reader, decrypter, securityContext)
        {
        }

        public override bool CanManageType(string filetype)
        {
            return filetype == ".xml";
        }
    }
}

