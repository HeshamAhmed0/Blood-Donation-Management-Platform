using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.DonationRequestExceptions
{
    public class DonationRequestNotFoundException : DonationRequestException
    {
        public DonationRequestNotFoundException(int Id ) : base($"DonationRequest With Id {Id} Not Found",404)
        {
           
        }

        public DonationRequestNotFoundException(string PhoneNumber) : base($"DonationRequest With PhoneNumber {PhoneNumber} Not Found", 404)
        {
        }
        public DonationRequestNotFoundException() : base($"DonationRequests Not Found", 404)
        {
        }
    }
}
