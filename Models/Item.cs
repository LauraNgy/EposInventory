using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace EposInventory.Models
{
    public class Item
    {
        public int ID { get; set; }
        public int ProviderID { get; set; }
        public string Description { get; set; }
        [Display(Name = "Price Per Unit")]
        public float PricePerUnit { get; set; }
        [Display(Name = "Selling Price")]
        public float SellingPrice { get;  set; }
        [Display(Name = "Quantity in Stock")]
        public int Stock { get; set; }
        [Display(Name = "Warning Level")]
        public int WarningLevel { get; set; }

        [Display(Name = "Markup")]
        public int Markup
        {
            get
            {
                var selling = Math.Round(SellingPrice, 2);
                var ppu = Math.Round(PricePerUnit, 2);
                return (int)((1-ppu/selling)*100);
            }
            set
            {
                Markup = 1;
            }
        }

        public virtual Provider Provider { get; set; }
    }
}