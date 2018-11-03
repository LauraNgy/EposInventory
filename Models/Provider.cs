using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EposInventory.Models
{

    public enum Day
    {
        Mon, Tue, Wed, Thu, Fri, Sat, Sun
    }

    public class Provider
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Day> OrderDays { get; set; }
        public ICollection<Day> DeliveryDays { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}