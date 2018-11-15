using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EposInventory.Models;

namespace EposInventory.DAL
{
    public class InventoryInitializer : System.Data.Entity.DropCreateDatabaseAlways<InventoryContext>
    {
        protected override void Seed(InventoryContext context)
        {
            var providers = new List<Provider>
            {
                new Provider { Name="Bertie Bott's", Address="3 Diagon Alley, Leaky Cauldron, London", PhoneNumber="0131 2478632", OrderDays="Monday, Wednesday", DeliveryDays= "Wednesday, Thursday" },
                new Provider { Name="Florian Fortescue", Address="5 Diagon Alley, Leaky Cauldron, London", PhoneNumber="0131 3567526", OrderDays="Friday, Wednesday", DeliveryDays= "Monday, Thursday" },
                new Provider { Name="Ollivander's", Address="14 Diagon Alley, Leaky Cauldron, London", PhoneNumber="0131 6555826", OrderDays="Thursday, Saturday", DeliveryDays="Friday, Monday" }
            };

            providers.ForEach(provider => context.Providers.Add(provider));
            context.SaveChanges();

            var items = new List<Item>
            {
                new Item { Description="Every Flavoured Beans", Category="Beans", PricePerUnit=2, SellingPrice=3, Stock=10, WarningLevel=10, ProviderID=1},
                new Item { Description="Bean Flavoured Beans", Category="Beans", PricePerUnit=2, SellingPrice=3, Stock=100, WarningLevel=10, ProviderID=1},
                new Item { Description="Dragon Egg Ice Cream", Category="Beans", PricePerUnit=4, SellingPrice=6, Stock=100, WarningLevel=10, ProviderID=2},
                new Item { Description="Strawberry Ice Cream", Category="Ice Cream", PricePerUnit=4, SellingPrice=6, Stock=100, WarningLevel=10, ProviderID=2},
                new Item { Description="Inspiration Ice Cream", Category="Ice Cream", PricePerUnit=4, SellingPrice=6, Stock=100, WarningLevel=10, ProviderID=2},
                new Item { Description="Chocolate Frogs Ice Cream", Category="Ice Cream", PricePerUnit=4, SellingPrice=6, Stock=10, WarningLevel=10, ProviderID=2},
                new Item { Description="Holly", Category="Wand", PricePerUnit=50, SellingPrice=150, Stock=100, WarningLevel=10, ProviderID=3},
                new Item { Description="Beech", Category="Wand", PricePerUnit=50, SellingPrice=150, Stock=100, WarningLevel=10, ProviderID=3},
                new Item { Description="Ash", Category="Wand", PricePerUnit=50, SellingPrice=150, Stock=10, WarningLevel=10, ProviderID=3},
                new Item { Description="Maple", Category="Wand", PricePerUnit=50, SellingPrice=150, Stock=1, WarningLevel=10, ProviderID=3},
                new Item { Description="Pine", Category="Wand", PricePerUnit=50, SellingPrice=150, Stock=100, WarningLevel=10, ProviderID=3},
                new Item { Description="Walnut", Category="Wand", PricePerUnit=50, SellingPrice=150, Stock=100, WarningLevel=10, ProviderID=3},
            };

            items.ForEach(item => context.Items.Add(item));
            context.SaveChanges();
        }
    }
}