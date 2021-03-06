﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Interfaces;

public abstract class BaseContext : DbContext
{
    public BaseContext()
    {
        //Database.SetInitializer<ShopaholicPlannerContext>(null);
    }

    protected BaseContext(string connString)
        :base(connString)
    {
    }
    
    public DbSet<ShoppingBasket> ShoppingBaskets { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        
    }    
}
