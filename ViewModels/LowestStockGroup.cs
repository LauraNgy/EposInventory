using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EposInventory.ViewModels
{
    public class LowestStockGroup
    {
        public string Description { get; set; }
        public string ProviderName { get; set;  }
        public string ProviderPhone { get; set; }
        public int Stock { get; set; }
    }
}