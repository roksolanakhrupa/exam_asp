using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_ASP.Models
{
    public class Comment
    {
        public int ID { get; set; }

        [Required]
        public string CommentText { get; set; }

      //  [ForeignKey("Post")]
        public int BookID { get; set; }
        [Required]
        public DateTime DateTime { get; set; }

        public virtual Book book { get; set; }
    }
}
