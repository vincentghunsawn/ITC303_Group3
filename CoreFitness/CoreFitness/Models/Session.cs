using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFitness.Models
{
    public class Session
    {

        public int Id { get; set; }

        [Required]
        public string ClassName { get; set; }
        [Required]
        public string InstructorName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime SessionTime { get; set; }

    }
}
