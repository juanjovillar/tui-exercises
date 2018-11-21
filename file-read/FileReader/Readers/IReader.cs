namespace FileReader.Readers
{
    public interface IReader
    {
        bool CanManageType(string filetype);

        string Read(string filePath);
    }
}
