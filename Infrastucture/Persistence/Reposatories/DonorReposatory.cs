using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracs;
using Domain.Meduls;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;

namespace Persistence.Reposatories
{
    public class DonorReposatory(BloodDonationDbContext bloodDonationDbContext) : IDonorReposatory
    {
        private readonly BloodDonationDbContext bloodDonationDbContext = bloodDonationDbContext;

        public async Task<Donor> GetDonorsByIdOrNameOrEmailOrPhoneNumber(string NameOrEmailOrPhoneNumber)
        {
           var result =await bloodDonationDbContext.Donors.FirstOrDefaultAsync(E=>E.Email == NameOrEmailOrPhoneNumber);
           if (result == null) result =await bloodDonationDbContext.Donors.FirstOrDefaultAsync(E => E.PhoneNumber == NameOrEmailOrPhoneNumber);
           if (result == null) result =await bloodDonationDbContext.Donors.FirstOrDefaultAsync(E => E.Name == NameOrEmailOrPhoneNumber);
            return result;
        }
        public async Task<Donor> GetDonorsByIdOrNameOrEmailOrPhoneNumber(int Id)
        {
            var result = await bloodDonationDbContext.Donors.FirstOrDefaultAsync(E => E.Id == Id);
            return result;
        }

    }
}
