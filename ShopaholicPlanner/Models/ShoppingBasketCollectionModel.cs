using System.Collections.Generic;

namespace ShopaholicPlanner.Models
{
    public class ShoppingBasketCollectionModel
    {
        public bool IsLoggedIn { get; set; }
        public List<ShoppingBasketModel> ShoppingBasketItems { get; set; } 
    }
}