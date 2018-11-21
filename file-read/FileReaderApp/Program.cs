using System;
using System.IO;
using System.Reflection;

namespace FileReaderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileReader = new FileReader.FileReader();
            var filePath = GetDefaultFilePath();

            var content = fileReader.Read(filePath);

            Console.Write(content);

            Console.ReadLine();
        }

        private static string GetDefaultFilePath()
        {
            var baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var relativeFilePath = @"Files\Text\TextFile.txt";
            var filePath = Path.Combine(baseDir, relativeFilePath);

            return filePath;
        }
    }
}
