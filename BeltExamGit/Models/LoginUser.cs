using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeltExam.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage ="is required")]
        [EmailAddress]
        [Display(Name ="Email")]
        public string LoginEmail {get; set;}

        [Required(ErrorMessage ="is required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage ="Must be at least 8 characters")]
        [Display(Name ="Password")]
        public string LoginPassword {get; set;}
        
    }
}