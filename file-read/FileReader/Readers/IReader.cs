namespace FileReader.Readers
{
    public interface IReader
    {
        bool CanReadFileType(string filetype);

        string Read(string filePath);
    }
}
