using System;

namespace FileReader.Cryptography.Algorithms
{
    public class ReverseDecryptor : IAlgorithm
    {
        public string Decrypt(string content)
        {
            var charArray = content.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
