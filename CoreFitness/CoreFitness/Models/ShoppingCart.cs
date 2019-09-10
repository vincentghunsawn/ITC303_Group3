using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFitness.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
       
        public string ProductName
        {
            get;
            set;
        }

        public string ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

    }
}
