using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFitness.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Name can only contain letters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Surname can only contain letters")]
        public string Surname { get; set; }
    }
}
