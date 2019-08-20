using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFitness.Models
{
    public class User : IdentityUser
    {
        
        public string Name { get; set; }
        
        public string Surname { get; set; }

    }
}
