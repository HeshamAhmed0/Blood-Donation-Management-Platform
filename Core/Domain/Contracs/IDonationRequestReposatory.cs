using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls;

namespace Domain.Contracs
{
    public interface IDonationRequestReposatory :IGenericReposatory<DonationRequest,int>
    {
        public Task<DonationRequest> GetDonationRequestByIdOrNameOrEmailOrPhoneNumber(string NameOrEmailOrPhoneNumber);
        public Task<DonationRequest> GetDonationRequestByIdOrNameOrEmailOrPhoneNumber(int ID);
    }
}
