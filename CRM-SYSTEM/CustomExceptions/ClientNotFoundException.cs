namespace CRM_SYSTEM.CustomExceptions
{
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException()
           : base("Client is not found!")
        {
        }
        public ClientNotFoundException(string message)
            : base(message)
        {
        }
        public ClientNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
