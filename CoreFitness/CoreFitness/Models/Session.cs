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
        public Days Day { get; set; }

        [DataType(DataType.Time)]
        public DateTime SessionStartTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime SessionEndTime { get; set; }

    }
}
