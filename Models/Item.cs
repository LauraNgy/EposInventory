using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EposInventory.Models
{
    public class Item
    {
        public int ID { get; set; }
        public int ProviderID { get; set; }
        public string Description { get; set; }
        public int PricePerUnit { get; set; }
        public int SellingPrice { get;  set; }
        public int Markup { get; set; }
        public int Stock { get; set; }
        public int WarningLevel { get; set; }

        public virtual Provider Provider { get; set; }
    }
}