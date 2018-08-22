using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopaholicPlanner.Models
{
    public class ShoppingBasketModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Product name")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
        public string Url { get; set; }

        [Required(ErrorMessage = "Currency is required")]
        public string Currency { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public Decimal Price { get; set; }
    }
}
