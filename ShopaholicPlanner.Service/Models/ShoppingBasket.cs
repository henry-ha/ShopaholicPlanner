using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("SP_SHOPPING_BASKET")]
public class ShoppingBasket : BaseEntity<int>
{
    [Key]
    public override int Id { get; set; }

    [StringLength(255)]
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public string Url { get; set; }
    public string Currency { get; set; }
    public Decimal Price { get; set; }
    public DateTime? UpdateDateUTC { get; set; }
    public DateTime? ArchiveDateUTC { get; set; }
    public User User { get; set; }
}
