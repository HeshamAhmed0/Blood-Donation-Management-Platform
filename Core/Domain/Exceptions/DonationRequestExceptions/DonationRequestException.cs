using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.DonationRequestExceptions
{
    public class DonationRequestException :Exception
    {

        public DonationRequestException(string Exception , int statusCode =404):base(Exception)
        {
        }


    }
}
