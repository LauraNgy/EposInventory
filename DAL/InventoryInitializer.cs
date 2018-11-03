using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EposInventory.Models;

namespace EposInventory.DAL
{
    public class InventoryInitializer :System.Data.Entity.DropCreateDatabaseIfModelChanges<InventoryContext>
    {
        protected override void Seed(InventoryContext context)
        {
            var providers = new List<Provider>
            {
                new Provider { Name="Bertie Bott's", Address="3 Diagon Alley, Leaky Cauldron, London", PhoneNumber="0131 2478632", OrderDays={ Day.Mon, Day.Wed }, DeliveryDays= {Day.Tue, Day.Thu} },
                new Provider { Name="Florian Fortescue", Address="5 Diagon Alley, Leaky Cauldron, London", PhoneNumber="0131 3567526", OrderDays={ Day.Wed, Day.Fri }, DeliveryDays= {Day.Mon, Day.Thu} },
                new Provider { Name="Ollivander's", Address="14 Diagon Alley, Leaky Cauldron, London", PhoneNumber="0131 6555826", OrderDays={ Day.Wed, Day.Sat }, DeliveryDays= {Day.Mon, Day.Fri} }
            };

            providers.ForEach(provider => context.Providers.Add(provider));
            context.SaveChanges();

            var items = new List<Item>
            {
                new Item { Description="Every Flavoured Beans", PricePerUnit=2, SellingPrice=3, Markup=33, Stock=100, WarningLevel=10, ProviderID=1},
                new Item { Description="Bean Flavoured Beans", PricePerUnit=2, SellingPrice=3, Markup=33, Stock=100, WarningLevel=10, ProviderID=1},
                new Item { Description="Dragon Egg Ice Cream", PricePerUnit=4, SellingPrice=6, Markup=33, Stock=100, WarningLevel=10, ProviderID=2},
                new Item { Description="Strawberry Ice Cream", PricePerUnit=4, SellingPrice=6, Markup=33, Stock=100, WarningLevel=10, ProviderID=2},
                new Item { Description="Inspiration Ice Cream", PricePerUnit=4, SellingPrice=6, Markup=33, Stock=100, WarningLevel=10, ProviderID=2},
                new Item { Description="Chocolate Frogs Ice Cream", PricePerUnit=4, SellingPrice=6, Markup=33, Stock=100, WarningLevel=10, ProviderID=2},
                new Item { Description="Holly", PricePerUnit=50, SellingPrice=150, Markup=200, Stock=100, WarningLevel=10, ProviderID=3},
                new Item { Description="Beech", PricePerUnit=50, SellingPrice=150, Markup=200, Stock=100, WarningLevel=10, ProviderID=3},
                new Item { Description="Ash", PricePerUnit=50, SellingPrice=150, Markup=200, Stock=100, WarningLevel=10, ProviderID=3},
                new Item { Description="Maple", PricePerUnit=50, SellingPrice=150, Markup=200, Stock=100, WarningLevel=10, ProviderID=3},
                new Item { Description="Pine", PricePerUnit=50, SellingPrice=150, Markup=200, Stock=100, WarningLevel=10, ProviderID=3},
                new Item { Description="Walnut", PricePerUnit=50, SellingPrice=150, Markup=200, Stock=100, WarningLevel=10, ProviderID=3},
            };

            items.ForEach(item => context.Items.Add(item));
            context.SaveChanges();
        }
    }
}