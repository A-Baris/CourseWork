﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.DTOs
{
    public class OrderDTO
    {
        public DateTime OrderDate { get; set; }
        public string ShipCountry { get; set; }
        public int TotalOrders { get; set; }

    }
}
