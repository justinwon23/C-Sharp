using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChefsDishes.Models
{
    public class Dish
    {
        public int Dishid {get; set;}

        [Required(ErrorMessage ="is required")]
        public string Name {get; set;}

        [Required(ErrorMessage = "is required")]
        [Range(1,int.MaxValue, ErrorMessage= "Every dish has calories!")]
        public int Calories { get; set; }

        [Required(ErrorMessage = "is required")]
        [Range(1,5)]
        public int Tastiness { get; set; }

        [Required(ErrorMessage = "is required")]
        public string Description { get; set; }
        
        [Display(Name = "Chef")]
        public int Chefid {get; set;}

        public Chef Writer {get; set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;        
    }
}