using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;

namespace Services
{
    public class SenderOptions
    {
        public const string EmailBlock = "Email";
        public string SourceEmail { get; set; }
        public string SourcePassword { get; set; }
        public int Port { get; set; }
        public string UseSSL { get; set; }
    }
    public class EmailSenderService
    {
        private readonly SenderOptions _secrets;

        public EmailSenderService(IConfiguration config){
            _secrets = new SenderOptions();
            config.GetSection(SenderOptions.EmailBlock).Bind(_secrets);
        }

        public async Task SendEmailAsync(string email, string subject, string message) => 
            await TrySend(BuildMessage(email, subject, message));

        private async Task TrySend(MimeMessage emailMessage)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.mail.ru", _secrets.Port, bool.Parse(_secrets.UseSSL));
                    await client.AuthenticateAsync(_secrets.SourceEmail, _secrets.SourcePassword);
                    await client.SendAsync(emailMessage);

                    await client.DisconnectAsync(true);

                    await Task.FromResult(emailMessage);
                }
            }
            catch(Exception e) { await Task.FromException(e); }
        }

        private MimeMessage BuildMessage(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Admimistration nVideo", _secrets.SourceEmail));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            return emailMessage;
        }
    }
}
