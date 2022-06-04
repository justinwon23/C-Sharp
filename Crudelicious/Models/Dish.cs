using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Crudelicious.Models
{
    public class Dish
    {
        [Key]
        public int CrudeliciousID {get; set;}
        
        [Required(ErrorMessage = "is required")]
        
        public string ChefsName { get; set; }

        [Required(ErrorMessage = "is required")]
        public string DishName { get; set; }

        [Required(ErrorMessage = "is required")]
        [Range(1,int.MaxValue, ErrorMessage= "Every dish has calories!")]
        public int Calories { get; set; }

        [Required(ErrorMessage = "is required")]
        [Range(1,5)]
        public int Tastiness { get; set; }

        [Required(ErrorMessage = "is required")]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}