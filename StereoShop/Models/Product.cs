using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StereoShop.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please select a product category.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Please enter the product code.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter the product name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the product price.")]
        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Slug
        {
            get
            {
                return (Name == null) ? "" : Name.Replace(' ', '-');
            }
        }
    }
}
