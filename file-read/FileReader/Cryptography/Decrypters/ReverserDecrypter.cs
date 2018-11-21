using System;

namespace FileReader.Cryptography.Decrypters
{
    public class ReverserDecrypter : IDecrypter
    {
       public string Decrypt(string content)
        {
            var charArray = content.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
