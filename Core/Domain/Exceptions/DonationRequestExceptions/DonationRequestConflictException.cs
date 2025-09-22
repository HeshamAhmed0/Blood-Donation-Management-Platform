using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls;

namespace Domain.Exceptions.DonationRequestExceptions
{
    public class DonationRequestConflictException : DonationRequestException
    {
        public DonationRequestConflictException(string Input) : base(BuildMessage(Input), 409)
        {
          
        }

        private static string BuildMessage(string input)
        {
            if (ValidatorHelper.IsValidEmail(input))
                return $"A DonationRequest with email {input} already exists.";

            if (ValidatorHelper.IsValidPhoneNumber(input))
                return $"A DonationRequest with phone {input} already exists.";

            return $"A DonationRequest with value {input} already exists.";
        }
    }
}
