using System;
using System.Collections.Generic;
using Interfaces;
using System.Data.Entity;

public class ShopaholicPlannerContext : BaseContext
{
    public ShopaholicPlannerContext() : base("DefaultConnection")
    {
    }

    //protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<ShoppingBasket>()
    //            .HasKey(c => new { c.Id, c.User });
        

    //    base.OnModelCreating(modelBuilder);
    //}
}
