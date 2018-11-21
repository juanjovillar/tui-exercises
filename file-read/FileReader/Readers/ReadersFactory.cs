using System.Collections.Generic;
using System.Linq;

namespace FileReader.Readers
{
    public class ReadersFactory
    {
        private readonly IEnumerable<IReader> _readers;

        public ReadersFactory()
        {
            _readers = new List<IReader>
            {
                new TextReader(),
                new XMLReader(),
            };
        }

        public IReader GetReader(string fileType)
        {
            var reader = _readers.Single(r => r.CanManageType(fileType));
            return reader;
        }
    }
}
