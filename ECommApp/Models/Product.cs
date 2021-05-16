using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(30, ErrorMessage = "The maximum length must be upto 30 characters only")]
        public string ProductName { get; set; }

        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Has to be decimal with two decimal points")]
       // [Range(0, 5, ErrorMessage = "The maximum possible value should be upto 5 digits")]
        public Decimal Price { get; set; }


        public string ImageURL { get; set; }
    }
}