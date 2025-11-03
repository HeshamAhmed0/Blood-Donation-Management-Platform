using Domain.Contracs;
using Domain.Meduls;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;
using Persistence.InitializeDatabase;
using Persistence.Reposatories;
using Services;
using ServicesAbstraction;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependancyInjection
    {
        public static IServiceCollection InfrustructionServices (this IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbInitialize, DbInitializer>();
            return services;
        } 
        public static IServiceCollection ReposatoriesServices (this IServiceCollection services)
        {
            services.AddScoped<IDonationHistoryReposatory, DonationHistoryReposatory>();
            services.AddScoped<IDonorReposatory, DonorReposatory>();
            services.AddScoped<IDonationRequestReposatory, DonationRequestReposatory>();

            return services;
        }
        public static IServiceCollection ApplicationServices (this IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IDonorService, DonorService>();
            services.AddScoped<IDonationRequestService, DonationRequestService>();
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IdonationHistoryService, DonationHistoryService>();

            return services;
        }
        public static IServiceCollection DbContextServices (this IServiceCollection services,IConfiguration configuration)
        {
           services.AddDbContext<BloodDonationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddIdentity<ApplicationUser, IdentityRole>()
                   .AddEntityFrameworkStores<BloodDonationDbContext>()
                   .AddDefaultTokenProviders();
           return services;
        }
    }
}
