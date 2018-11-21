﻿using FileReader.Cryptography.Decrypters;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileReader.FileReaders;
using FileReader.Readers;
using FileReader.Security;
using TextReader = FileReader.Readers.TextReader;

namespace FileReader
{
    public class FileReaderFactory
    {
        private readonly IEnumerable<FileReader> _readers;

        public FileReaderFactory()
        {
            _readers = new List<FileReader>
            {
                new FileReaders.TextFileReader(
                    new TextReader(), 
                    new ReverserDecrypter(),
                    new SecurityContext()),

                new XMLFileReader(
                    new XMLReader(),
                    new XMLReverseDecrypter(),
                    new SecurityContext()),

                new JsonFileReader(
                    new JsonReader())
            };
        }

        public FileReader CreateReader(string filepath)
        {
            var fileInfo = new FileInfo(filepath);
            return _readers.Single(r => r.CanManageType(fileInfo.Extension));
        }
    }
}
