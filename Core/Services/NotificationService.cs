using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ServicesAbstraction;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Services
{
    public class NotificationService : INotificationService
    {
        private readonly IConfiguration configuration;

        public NotificationService(IConfiguration configuration)
        {
            this.configuration = configuration;
            TwilioClient.Init(
                configuration["Twilio:AccountSid"],
                configuration["Twilio:AuthToken"]
                );
        }

        public async Task SendEmailAsync(string phoneNumber, string PatinetName, string body, double latitude, double longitude)
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
            var Subject = $"مطلوب تبرع بالدم - اسم المريض: {PatinetName}";
            var Body = $@"السلام عليكم ورحمة الله، 
محتاجين تبرع بالدم بنفس فصيلة دمك. 

اسم المريض: {PatinetName}
العنوان: {body}
رابط الموقع على الخريطة: {googleMapsLink}";

            var MaiMessage = new MailMessage(from, phoneNumber, Subject, Body);
            await smtpClient.SendMailAsync(MaiMessage);
        }

        //public async Task SendSmsAsync(string phoneNumber, string PatinetName, double latitude, double longitude)
//        {
//            string FromNumber = configuration["Twilio:FromNumber"];
//            if (phoneNumber.StartsWith("0"))
//                phoneNumber = phoneNumber.Substring(1);
//            var countryCode = "+20";
//            if (!phoneNumber.StartsWith("+"))
//                phoneNumber = countryCode + phoneNumber;
//            var googleMapsLink = $"https://www.google.com/maps?q={latitude},{longitude}";
//            var message = $@"السلام عليكم
//اهلا بحضرتك
//محتاجين متبرع بالدم بنفس فصيله دمك
//العنوان : {googleMapsLink}
//";
//            var result = await MessageResource.CreateAsync(
//                body: message,
//                from: FromNumber,
//                to: new PhoneNumber(phoneNumber)
//                );
//            if( result.ErrorCode != null )
//            {
//                throw new Exception("Exception Occure While Send Sms");
//            }
//        }


    }
}
