using System;
using System.Text;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace MustangAlley.Services
{
    public class MessageService : IEmailSender
    {
        private IConfiguration configuration;

        public MessageService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public void SendEmail(string email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Registration Confirmation", "Registration.Confirmation@mustangalleyon9.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Registration Successful";

            var sb = new StringBuilder();

            sb.AppendLine("Congratulations – you are registered for the 21th annual Mustang Alley! To help keep the event fun and safe, we do have a few requirements. Please check the web-site for those requirements and other event details. We look forward to seeing you in Ferndale, and hope you enjoy the event!");
            sb.AppendLine(Environment.NewLine);
            sb.AppendLine(Environment.NewLine);
            sb.AppendLine("The Mustang Alley Team");

            message.Body = new TextPart("plain")
            {
                Text = sb.ToString()
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.sendgrid.net", 587, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                
                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(configuration["SendGridUser"], configuration["SendGridPassword"]);

                client.Send(message);
                client.Disconnect(true);
            }
        }

        public void SendMessageReceivedEmail(string email, string name, string messageBody)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(name, email));
            message.To.Add(new MailboxAddress("Mustang Alley Support", "mustangalleyon9@gmail.com"));
            message.Subject = string.Format("Message from {0} on {1}", name, DateTime.Now.ToString("g"));

            var sb = new StringBuilder();

            sb.AppendFormat("From: {0}", name);
            sb.AppendLine(Environment.NewLine);
            sb.AppendFormat("Email: {0}", email);
            sb.AppendLine(Environment.NewLine);
            sb.AppendLine(messageBody);

            message.Body = new TextPart("plain")
            {
                Text = sb.ToString()
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.sendgrid.net", 587, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(configuration["SendGridUser"], configuration["SendGridPassword"]);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
