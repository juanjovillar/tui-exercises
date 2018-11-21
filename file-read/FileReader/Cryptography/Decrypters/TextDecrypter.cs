using FileReader.Cryptography.Algorithms;

namespace FileReader.Cryptography.Decrypters
{
    public class TextDecrypter : IDecrypter
    {
        public bool CanManageType(string filetype)
        {
            return filetype == ".txt";
        }

        public string Decrypt(IAlgorithm algorithm, string content)
        {
            return algorithm.Decrypt(content);
        }
    }
}
