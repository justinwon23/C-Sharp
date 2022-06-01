using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [MinLength(4)]
        public string FName {get; set;}

        [Required]
        [MinLength(4)]
        public string LName {get; set;}
        
        [Required]
        [Range(1,100)]
        
        public int Age {get; set;}

        [Required]
        [EmailAddress]
        public string Email {get; set;}
        
        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}
    }
}