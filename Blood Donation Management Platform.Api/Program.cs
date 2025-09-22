
using Domain.Contracs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DbContexts;
using Persistence.InitializeDatabase;
using Persistence.Reposatories;
using Services;
using Services.MappingProfiles;
using ServicesAbstraction;

namespace Blood_Donation_Management_Platform.Api
{
    public class Program
    {
        public  static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDbInitialize,DbInitializer>();
            builder.Services.AddScoped<IDonorReposatory,DonorReposatory>();
            builder.Services.AddScoped<IDonorService,DonorService>();
            builder.Services.AddScoped<IDonationRequestReposatory,DonationRequestReposatory>();
            builder.Services.AddScoped<IDonationRequestService,DonationRequestService>();
            builder.Services.AddScoped<IServiceManager,ServiceManager>();
            //builder.Services.AddAutoMapper(typeof(AssemplyForAutoMapper).Assembly);
            builder.Services.AddDbContext<BloodDonationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            var app = builder.Build();

            #region DbInitialize
            using(var Scope =app.Services.CreateScope())
            {
                var DbInitializeForApp = Scope.ServiceProvider.GetService<IDbInitialize>();
                await DbInitializeForApp.InitializeAsync();
            }
            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
