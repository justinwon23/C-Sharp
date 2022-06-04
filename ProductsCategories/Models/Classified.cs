using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsCategories.Models
{
    public class Classified
    {
        [Key]
        public int Classifiedid {get; set;}
        public int Productid {get; set;}
        public Product Product {get; set;}
        public int Categoryid {get; set;}
        public Category Category {get; set;}


    }
}