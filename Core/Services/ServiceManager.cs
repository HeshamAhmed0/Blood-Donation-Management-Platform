using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracs;
using Microsoft.Extensions.Configuration;
using Persistence.DbContexts;
using ServicesAbstraction;

namespace Services
{
    public class ServiceManager(IUnitOfWork unitOfWork,IDonorReposatory donorReposatory,IDonationRequestReposatory donationRequestReposatory
                                 ,IConfiguration configuration,IDonorService donorService,INotificationService notificationService,IDonationRequestService donationRequestService) : IServiceManager
    {

        public IDonorService donorService { get; } =new DonorService(unitOfWork,donorReposatory);

        public IDonationRequestService donationRequestService { get; } =new DonationRequestService(donationRequestReposatory,unitOfWork,donorService,notificationService);

        public INotificationService notificationService { get; } = new NotificationService( configuration);

        public IDashboardService dashboardService { get; } = new DashboardService(unitOfWork,donorService,donationRequestService);
    }
}
