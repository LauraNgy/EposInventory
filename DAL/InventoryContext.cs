using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EposInventory.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EposInventory.DAL
{
    public class InventoryContext : DbContext
    {
        public InventoryContext() : base("InventoryContext")
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Provider> Providers { get; set; }
        
    }
}