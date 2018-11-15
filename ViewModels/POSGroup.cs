using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EposInventory.ViewModels
{
    public class POSGroup
    {
        public string Description { get; set; }
        public string Category { get; set; }
        public float SellingPrice { get; set; }
        public int Stock { get; set; }
    }
}