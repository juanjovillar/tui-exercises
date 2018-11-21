using FileReader;
using FileReader.Security;
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
                @"Files\XML\AdminXMLFile.xml",

            };

            CreateFileReadRequest(systemFilePaths[0], false, Roles.User);

            CreateFileReadRequest(systemFilePaths[1], false, Roles.User);

            CreateFileReadRequest(systemFilePaths[1], true, Roles.User);

            CreateFileReadRequest(systemFilePaths[2], false, Roles.User);

            CreateFileReadRequest(systemFilePaths[3], false, Roles.User);            

            CreateFileReadRequest(systemFilePaths[3], false, Roles.Admin);

            Console.ReadLine();
        }

        private static void CreateFileReadRequest(string filePath, bool decrypt, Roles role)
        {
            var request = new FileReadRequest(filePath, decrypt, role);
            Console.WriteLine($"REQUEST -> File: {request.FilePath} | Decrypt: {request.ShouldDecrypt} | Role: {request.UserRole}");
            ReadFile(request);
            Console.WriteLine();
        }

        private static void ReadFile(FileReadRequest request)
        {
            var fileReader = new FileReaderFactory().CreateReader(request.FilePath);
            var content = fileReader.Read(request);
            Console.WriteLine(content);
        }
    }
}
