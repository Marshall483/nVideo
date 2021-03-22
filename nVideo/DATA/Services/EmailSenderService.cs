﻿using MimeKit;
using nVideo.DATA.Interfaces;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace nVideo.DATA.Services
{
    public class SenderOptions
    {
        public const string EmailBlock = "Email";
        public string SourceEmail { get; set; }
        public string SourcePassword { get; set; }
        public int Port { get; set; }
        public int UseSSL { get; set; }
    }
    public class EmailSenderService
    {
        private static SenderOptions _secrets { get; set; }
        public EmailSenderService(IConfiguration config){
            _secrets = new SenderOptions();
            config.GetSection(SenderOptions.EmailBlock).Bind(_secrets);
        }
                                
        public async Task SendEmailAsync(string email, string subject, string message){
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация nVideo", _secrets.SourceEmail));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html){
                Text = message
            };

            using (var client = new SmtpClient()){
                await client.ConnectAsync("smtp.mail.ru", _secrets.Port, _secrets.UseSSL == 1 ? true : false);
                await client.AuthenticateAsync(_secrets.SourceEmail, _secrets.SourcePassword);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }

    }
}
