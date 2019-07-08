using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_ASP.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
