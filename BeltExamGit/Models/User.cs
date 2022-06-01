using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeltExam.Models
{
    public class User
    {
        
        
        [Key]
        public int UserId {get; set;}

        [Required(ErrorMessage ="is required")]
        [MinLength(2, ErrorMessage ="Must be at least 2 characters")]
        [Display(Name ="First Name")]
        public string FirstName {get; set;}
        
        [Required(ErrorMessage ="is required")]
        [MinLength(2, ErrorMessage ="Must be at least 2 characters")]
        [Display(Name ="Last Name")]
        public string LastName {get; set;}

        [Required(ErrorMessage ="is required")]
        [EmailAddress]
        public string Email {get; set;}

        [Required(ErrorMessage ="is required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage ="Must be at least 8 characters")]
        public string Password {get; set;}

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        public string Confirm {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

        public string FullName ()
        {
            return FirstName + " " + LastName;
        }

        public List<Event> PlannedEvents {get; set;}
        public List<EventUserJoin> EventUserJoins {get; set;}


    }
}