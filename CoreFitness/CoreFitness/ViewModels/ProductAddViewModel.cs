using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CoreFitness.Models;
using Microsoft.AspNetCore.Http;

namespace CoreFitness.ViewModels
{
    public class ProductAddViewModel
    {
        
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters")]
        public string Name { get; set; }
        [Required]
        [MinLength(20, ErrorMessage ="Minimum 20 characters required")]
        public string Description { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Price must be a number")]
        public string Price { get; set; }
        [Required]
        public Availability Availability { get; set; }
        public IFormFile Photo { get; set; } 


    }
}
