using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Meduls
{
    public class ApplicationUser :IdentityUser
    {
        public string FullName { get; set; }
        public string Role {  get; set; }
    }
}
