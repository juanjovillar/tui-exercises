using System.Collections.Generic;
using System.Linq;

namespace FileReader.Cryptography.Decrypters
{
    public class DecryptersFactory
    {
        private readonly IEnumerable<IDecrypter> _readers;

        public DecryptersFactory()
        {
            _readers = new List<IDecrypter>
            {
                new TextDecrypter(),
            };
        }

        public IDecrypter GetDecrypter(string fileType)
        {
            var decrypter = _readers.Single(r => r.CanManageType(fileType));
            return decrypter;
        }
    }
}
