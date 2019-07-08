using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_ASP.Models
{
    public class Genre
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
