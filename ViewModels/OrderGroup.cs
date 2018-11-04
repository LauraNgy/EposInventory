using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EposInventory.ViewModels
{
    public class OrderGroup
    {
        public string Name;
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber;
    }
}