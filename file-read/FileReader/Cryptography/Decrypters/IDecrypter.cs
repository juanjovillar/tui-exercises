using FileReader.Cryptography.Algorithms;

namespace FileReader.Cryptography.Decrypters
{
    public interface IDecrypter
    {
        bool CanManageType(string filetype);

        string Decrypt(IAlgorithm algorithm, string content);
    }
}
