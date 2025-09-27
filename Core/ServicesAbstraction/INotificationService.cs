using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstraction
{
    public interface INotificationService
    {
        Task SendEmailAsync(string to, string subject, string body,double latitude ,double longitude);
        Task SendSmsAsync(string phoneNumber, string message);
        Task SendWhatsAppAsync(string phoneNumber, string message);
    }
}
