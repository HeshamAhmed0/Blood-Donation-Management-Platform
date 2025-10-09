using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls;

namespace Domain.Exceptions.DonorExceptions
{
    public class DonorConflictException : DonationRequestException
    {
        public DonorConflictException() : base($"A donor with This Data already exists.", 409)
        {
        }
    }
}
