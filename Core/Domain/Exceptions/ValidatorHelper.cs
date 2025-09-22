using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public static class ValidatorHelper
    {
        public static bool IsValidEmail(string Input)
        {
            return new EmailAddressAttribute().IsValid(Input);
        }
        public static bool IsValidPhoneNumber(string Input)
        {
            return Input.All(char.IsDigit) || (Input.StartsWith("+") && Input.Skip(1).All(char.IsDigit));
        }
    }
}
