using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace EposInventory.Models
{

    public enum Day
    {
        Mon, Tue, Wed, Thu, Fri, Sat, Sun
    }

    public class Provider
    {

        public int ID { get; set; }
        [Display(Name = "Name")]
        public string ProviderName { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Ordering Days")]
        public ICollection<Day> OrderDays { get; set; }
        [Display(Name = "Delivery Days")]
        public ICollection<Day> DeliveryDays { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public Provider()
        {
            OrderDays = new List<Day>();
            DeliveryDays = new List<Day>();
            Items = new List<Item>();
        }
    }
}