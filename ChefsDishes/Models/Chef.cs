using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChefsDishes.Models
{
    public class Chef
    {
        [Key]
        public int Chefid {get; set;}
        
        [Required(ErrorMessage ="is required")]
        [Display(Name = "First Name")]
        public string FirstName {get; set;}

        [Required(ErrorMessage ="is required")]
        [Display(Name = "Last Name")]
        public string LastName {get; set;}

        [Required(ErrorMessage ="is required")]
        [FutureDate]
        
        
        public DateTime DOB {get; set;}

        public List<Dish> SubmittedDishes {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        public int Age()
        {
            string [] dobDateParts = DOB.ToShortDateString().Split("/");
            string [] todayDateParts = DateTime.Now.ToShortDateString().Split("/");

            int age = Int32.Parse(todayDateParts[2]) - Int32.Parse(dobDateParts[2]);

            return age;
        }



    }
}