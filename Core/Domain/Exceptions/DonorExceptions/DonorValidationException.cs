using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.DonorExceptions
{
    public class DonorValidationException : DonorException
    {
      
        public DonorValidationException() : base("Donor data cannot be null", 400)
        {
            
        }
    }
}
