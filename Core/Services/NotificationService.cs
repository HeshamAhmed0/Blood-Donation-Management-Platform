using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ServicesAbstraction;

namespace Services
{
    public class NotificationService : INotificationService
    {
        private readonly IConfiguration configuration;

        public NotificationService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmailAsync(string to, string subject, string body, double latitude, double longitude)
        {
            var from = configuration["EmailSettings:From"];
            var username = configuration["EmailSettings:Username"];
            var password = configuration["EmailSettings:Password"];
            var smtpServer = configuration["EmailSettings:SmtpServer"];
            var port = int.Parse(configuration["EmailSettings:Port"]);

            using var smtpClient = new SmtpClient(smtpServer, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };
            var googleMapsLink = $"https://www.google.com/maps?q={latitude},{longitude}";
            var Subject = $"مطلوب تبرع بالدم - اسم المريض: {subject}";
            var Body = $@"السلام عليكم ورحمة الله، 
محتاجين تبرع بالدم بنفس فصيلة دمك. 

اسم المريض: {subject}
العنوان: {body}
رابط الموقع على الخريطة: {googleMapsLink}";

            var MaiMessage = new MailMessage(from,to, Subject, Body);
            await smtpClient.SendMailAsync(MaiMessage);
        }

        public Task SendSmsAsync(string phoneNumber, string message)
        {
            throw new NotImplementedException();
        }

        public Task SendWhatsAppAsync(string phoneNumber, string message)
        {
            throw new NotImplementedException();
        }
    }
}
