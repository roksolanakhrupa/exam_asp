using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_ASP.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

       
    }
}
