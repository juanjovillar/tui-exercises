using FileReader.Cryptography.Decrypters;
using FileReader.Readers;
using FileReader.Security;

namespace FileReader.FileReaders
{
    public class TextFileReader : AbstractFileReader
    {
        public TextFileReader(
            IReader reader,
            IDecrypter decrypter,
            ISecurityContext securityContext)
            : base(reader, decrypter, securityContext)
        {
        }

        public override bool CanManageType(string filetype)
        {
            return filetype == ".txt";
        }
    }
}

