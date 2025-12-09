namespace CRM_SYSTEM.CustomExceptions
{
    public class ClientAlreadyExistsException : Exception
    {
        public ClientAlreadyExistsException()
            : base("Client already exists!")
        {
        }
        public ClientAlreadyExistsException(string message)
            : base(message)
        {
        }
        public ClientAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
