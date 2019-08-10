using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFitness.ViewModels
{
    public class ProductEditViewModel : ProductAddViewModel
    {

        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
