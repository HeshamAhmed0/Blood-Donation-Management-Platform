using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.DonorExceptions
{
    public class DonorException :Exception
    {
        public int StatusCode { get; set; }

        public DonorException(string Exception , int statusCode =404):base(Exception)
        {
          StatusCode = statusCode;
        }


    }
}
