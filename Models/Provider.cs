using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace EposInventory.Models
{

    public class Provider
    {

        public int ID { get; set; }
        public string ProviderName { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Ordering Days")]
        public string OrderDays { get; set; }
        [Display(Name = "Delivery Days")]
        public string DeliveryDays { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public Provider()
        {
            Items = new List<Item>();
        }
    }
}