using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StereoShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter the category name.")]
        public string Name { get; set; }
    }
}
