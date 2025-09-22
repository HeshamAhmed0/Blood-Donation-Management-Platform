using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls;

namespace Domain.Contracs
{
    public interface IDonorReposatory :IGenericReposatory<Donor,int>
    {
        public Task<Donor> GetDonorsByIdOrNameOrEmailOrPhoneNumber(string NameOrEmailOrPhoneNumber);
        public Task<Donor> GetDonorsByIdOrNameOrEmailOrPhoneNumber(int ID);

    }
}
