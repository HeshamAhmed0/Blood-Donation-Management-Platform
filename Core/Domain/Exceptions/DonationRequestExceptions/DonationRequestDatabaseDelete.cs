using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Exceptions.DonationRequestExceptions
{
    public class DonationRequestDatabaseDelete : DonationRequestException
    {
        public DonationRequestDatabaseDelete() : base("An unexpected error occurred while Deleting DonationRequest", 500)
        {
        }
    }
}
