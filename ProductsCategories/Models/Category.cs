using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProductsCategories.Models
{
    public class Category
    {
        [Key]
        public int Categoryid {get; set;}

        [Required(ErrorMessage ="is required")]
        
        public string Name {get; set;}

        public List<Classified> Belongings {get; set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}