using System;
using System.Collections.Generic;

namespace FileReaderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var systemFilePaths = new List<string>
            {
                @"Files\Text\TextFile.txt",
                @"Files\Text\EncryptedTextFile.txt",
                @"Files\XML\XMLFile.xml",
            };

            var fileReader = new FileReader.FileReader();

            Console.WriteLine(fileReader.Read(systemFilePaths[0], false));
            Console.WriteLine();

            Console.WriteLine(fileReader.Read(systemFilePaths[1], true));
            Console.WriteLine();

            Console.WriteLine(fileReader.Read(systemFilePaths[2], false));
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
