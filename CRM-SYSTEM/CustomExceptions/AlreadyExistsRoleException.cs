namespace CRM_SYSTEM.CustomExceptions
{
    public class AlreadyExistsRoleException : Exception
    {
        public AlreadyExistsRoleException()
            : base("Role is already exists!")
        {
        }
        public AlreadyExistsRoleException(string message)
            : base(message)
        {
        }
        public AlreadyExistsRoleException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
