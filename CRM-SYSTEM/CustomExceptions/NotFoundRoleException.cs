namespace CRM_SYSTEM.CustomExceptions
{
    public class NotFoundRoleException : Exception
    {
        public NotFoundRoleException()
            : base("Role not found!")
        {
        }
        public NotFoundRoleException(string message)
            : base(message)
        {
        }
        public NotFoundRoleException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
