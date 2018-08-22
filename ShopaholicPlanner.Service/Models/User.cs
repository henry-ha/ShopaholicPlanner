using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("AspNetUsers")]
public class User
{
    public string Id { get; set; }

    [StringLength(100)]
    public string UserName { get; set; }
    public string Email { get; set; }
    public ICollection<ShoppingBasket> ShoppingBasket { get; set; }
}
