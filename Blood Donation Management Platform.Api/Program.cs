
using Domain.Contracs;
using Domain.Meduls;
using Microsoft.AspNetCore.Identity; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DbContexts;
using Persistence.InitializeDatabase;
using Persistence.Reposatories;
using Services;
using Services.MappingProfiles;
using  ServicesAbstraction;

namespace Blood_Donation_Management_Platform.Api
{
    public class Program
    {
        public  static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.InfrustructionServices();
            builder.Services.DbContextServices(builder.Configuration);
            builder.Services.ApplicationServices();
            builder.Services.ReposatoriesServices();

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
            //if (app.Environment.IsDevelopment())
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
