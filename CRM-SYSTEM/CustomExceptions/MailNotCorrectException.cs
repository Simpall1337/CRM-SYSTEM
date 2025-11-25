namespace CRM_SYSTEM.CustomExceptions
{
    public class MailNotCorrectException: Exception
    {
        public MailNotCorrectException()
        : base("Email address is not in correct format")
        {
        }

        public MailNotCorrectException(string message)
            : base(message)
        {
        }

        public MailNotCorrectException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
