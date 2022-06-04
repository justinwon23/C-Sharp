using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProductsCategories.Models
{
    public class Product
    {
        [Key]
        public int Productid {get; set;}

        [Required(ErrorMessage ="is required")]
        public string Name {get; set;}

        [Required(ErrorMessage ="is required")]
        public float Price {get; set;}

        [Required(ErrorMessage ="is required")]
        public string Description {get; set;}

        public List<Classified> Classified {get; set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}