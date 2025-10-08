using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Configrations;
namespace Persistence.DbContexts
{
    public class BloodDonationDbContext :IdentityDbContext<ApplicationUser>
    {
        public BloodDonationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AsemblyForConfigrations).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<DonationRequest> DonationsRequests { get; set; }
        public  DbSet<DonationHistory> DonationHistories { get; set; }
    }
}
