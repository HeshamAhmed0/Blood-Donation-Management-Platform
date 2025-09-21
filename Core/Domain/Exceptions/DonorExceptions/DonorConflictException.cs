using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls;

namespace Domain.Exceptions.DonorExceptions
{
    public class DonorConflictException : DonorException
    {
        public DonorConflictException(string Email) : base($"A donor with email {Email} already exists.", 409)
        {
        }
    }
}
