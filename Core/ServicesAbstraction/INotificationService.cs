using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstraction
{
    public interface INotificationService
    {
        Task SendEmailAsync(string phoneNumber, string PatinetName, string body,double latitude ,double longitude);
        //Task SendSmsAsync(string phoneNumber, string PatinetName, double latitude, double longitude);
    }
}
