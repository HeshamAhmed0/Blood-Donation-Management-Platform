using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.DonorExceptions
{
    public class DonorNotFoundException : DonorException
    {
        public DonorNotFoundException(int Id ) : base($"Donor With Id {Id} Not Found",404)
        {
           
        }

        public DonorNotFoundException(string PhoneNumber) : base($"Donor With PhoneNumber {PhoneNumber} Not Found", 404)
        {
        }
        public DonorNotFoundException() : base($"Donors Not Found", 404)
        {
        }
    }
}
