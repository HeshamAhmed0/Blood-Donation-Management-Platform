using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Exceptions.DonorExceptions
{
    public class DonorDatabaseDelete : DonationRequestException
    {
        public DonorDatabaseDelete() : base("An unexpected error occurred while Deleting donor", 500)
        {
        }
    }
}
