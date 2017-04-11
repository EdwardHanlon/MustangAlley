namespace MustangAlley.Services
{
    public interface IEmailSender
    {
        void SendEmail(string email);
        void SendMessageReceivedEmail(string email, string name, string message);
    }
}
