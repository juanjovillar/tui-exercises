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
                @"Files\XML\XMLFile.xml"
            };

            var fileReader = new FileReader.FileReader();

            systemFilePaths.ForEach(f =>
            {
                var content = fileReader.Read(f);
                Console.WriteLine(content);
                Console.WriteLine();
            });

            Console.ReadLine();
        }
    }
}
