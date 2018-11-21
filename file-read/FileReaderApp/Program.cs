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
            ExecuteTextFileReadRequests();

            ExecuteXMLFileReadRequests();

            ExecuteJSONFileReadRequests();

            Console.ReadLine();
        }

        private static void ReadFile(FileReadRequest request)
        {
            var fileReader = new FileReaderFactory().CreateReader(request.FilePath);
            var content = fileReader.Read(request);
            Console.WriteLine(content);
        }

        private static void CreateFileReadRequest(string filePath, bool decrypt, Roles role)
        {
            var request = new FileReadRequest(filePath, decrypt, role);
            Console.WriteLine($"REQUEST -> File: {request.FilePath} | Decrypt: {request.ShouldDecrypt} | Role: {request.UserRole}");
            ReadFile(request);
            Console.WriteLine();
        }

        private static void ExecuteTextFileReadRequests()
        {
            var textFilePaths = new List<string>
            {
                @"Files\Text\TextFile.txt",
                @"Files\Text\EncryptedTextFile.txt",
                @"Files\Text\AdminTextFile.txt",
            };

            Console.WriteLine("Executing TEXT file reads");
            Console.WriteLine("-------------------------");

            CreateFileReadRequest(textFilePaths[0], false, Roles.User);
            CreateFileReadRequest(textFilePaths[1], false, Roles.User);
            CreateFileReadRequest(textFilePaths[1], true, Roles.User);
            CreateFileReadRequest(textFilePaths[2], false, Roles.User);
            CreateFileReadRequest(textFilePaths[2], false, Roles.Admin);
        }

        private static void ExecuteXMLFileReadRequests()
        {
            var xmlFilePaths = new List<string>
            {
                @"Files\XML\XMLFile.xml",
                @"Files\XML\EncryptedXMLFile.xml",
                @"Files\XML\AdminXMLFile.xml",
            };

            Console.WriteLine("Executing XML file reads");
            Console.WriteLine("-------------------------");

            CreateFileReadRequest(xmlFilePaths[0], false, Roles.User);
            CreateFileReadRequest(xmlFilePaths[1], false, Roles.User);
            CreateFileReadRequest(xmlFilePaths[1], true, Roles.User);
            CreateFileReadRequest(xmlFilePaths[2], false, Roles.User);
            CreateFileReadRequest(xmlFilePaths[2], false, Roles.Admin);
        }

        private static void ExecuteJSONFileReadRequests()
        {
            var jsonFilePaths = new List<string>
            {
                @"Files\JSON\JsonFile.json",
            };

            Console.WriteLine("Executing JSON file reads");
            Console.WriteLine("-------------------------");

            CreateFileReadRequest(jsonFilePaths[0], false, Roles.User);
        }
    }
}
