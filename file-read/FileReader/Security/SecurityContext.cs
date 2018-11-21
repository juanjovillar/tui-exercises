namespace FileReader.Security
{
    public class SecurityContext : ISecurityContext
    {
        public bool ValidateRequest(FileReadRequest request)
        {
            if (request.UserRole == Roles.Admin)
            {
                return true;
            }

            return !request.FilePath.Contains("Admin");
        }
    }
}
