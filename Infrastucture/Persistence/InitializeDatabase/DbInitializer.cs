using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracs;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;

namespace Persistence.InitializeDatabase
{
    public class DbInitializer(BloodDonationDbContext bloodDonationDbContext) : IDbInitialize
    {
        public async Task InitializeAsync()
        {
            if(bloodDonationDbContext.Database.GetPendingMigrations().Any())
            {
                await bloodDonationDbContext.Database.MigrateAsync();
            }
        }
    }
}
