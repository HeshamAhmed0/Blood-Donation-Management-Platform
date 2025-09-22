using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Exceptions.DonorExceptions
{
    public class DonorDatabaseException : DonationRequestException
    {
        public DonorDatabaseException() : base("An unexpected error occurred while saving donor", 500)
        {
        }
    }
}
