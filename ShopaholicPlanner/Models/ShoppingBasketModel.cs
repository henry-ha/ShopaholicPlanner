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
        public int Quantity { get; set; }
        public string Url { get; set; }
        public string Currency { get; set; }
        public Decimal Price { get; set; }
    }
}
