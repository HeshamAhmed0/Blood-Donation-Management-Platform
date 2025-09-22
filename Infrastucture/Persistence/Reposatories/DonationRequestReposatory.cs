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
    public class DonationRequestReposatory : GenericReposatory<DonationRequest, int>, IDonationRequestReposatory
    {
        private readonly BloodDonationDbContext bloodDonationDbContext;

        public DonationRequestReposatory(BloodDonationDbContext bloodDonationDbContext) : base(bloodDonationDbContext)
        {
            this.bloodDonationDbContext = bloodDonationDbContext;
        }

        public async Task<DonationRequest> GetDonationRequestByIdOrNameOrEmailOrPhoneNumber(string NameOrEmailOrPhoneNumber)
        {
            var result =await bloodDonationDbContext.DonationsRequests.FirstOrDefaultAsync(D=>D.PatientName==NameOrEmailOrPhoneNumber);
            if (result == null) return await bloodDonationDbContext.DonationsRequests.FirstOrDefaultAsync(D => D.PhoneNumber == NameOrEmailOrPhoneNumber);
            if (result == null) return await bloodDonationDbContext.DonationsRequests.FirstOrDefaultAsync(D => D.Email == NameOrEmailOrPhoneNumber);
            return result;
        }

        public async Task<DonationRequest> GetDonationRequestByIdOrNameOrEmailOrPhoneNumber(int ID)
        {
            var result = await bloodDonationDbContext.DonationsRequests.FirstOrDefaultAsync(D => D.Id == ID);
            return result;
        }
    }
}
