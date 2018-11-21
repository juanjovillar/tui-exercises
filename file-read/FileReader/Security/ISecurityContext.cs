namespace FileReader.Security
{
    public interface ISecurityContext
    {
        bool ValidateRequest(FileReadRequest request);
    }
}
