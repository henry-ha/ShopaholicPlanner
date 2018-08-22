using System;
using System.Collections.Generic;
using Interfaces;
using System.Data.Entity;

public class ShopaholicPlannerContext : BaseContext
{
    public ShopaholicPlannerContext() : base("DefaultConnection")
    {
        //Disable initializer
        Database.SetInitializer<ShopaholicPlannerContext>(null);
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
