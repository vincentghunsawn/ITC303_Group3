using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoreFitness.Models
{
    public class Product
    {
        public int Id
        {
            get;
            set;
        }
        [Required]
        public string Name
        {
            get;
            set;
        }
        [Required]
        public string Description
        { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Price must be a number")]
        public string Price
        {
            get;
            set;
        }
        public Availability Availability
        {
            get;
            set;
        }
        public string ImageURL
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

    }
}