using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_ASP.Models
{
    public class Book
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Author Name")]
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }

        [Required]
        [Display(Name="Genre")]
        public int GenreID { get; set; }
        public virtual Genre Genre { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }
    }
}
