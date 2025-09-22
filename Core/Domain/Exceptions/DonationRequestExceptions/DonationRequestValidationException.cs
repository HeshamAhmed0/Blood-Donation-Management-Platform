using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.DonationRequestExceptions
{
    public class DonationRequestValidationException : DonationRequestException
    {
      
        public DonationRequestValidationException() : base("DonationRequest data cannot be null", 400)
        {
            
        }
    }
}
