using Microsoft.EntityFrameworkCore;
using Northwind.BLL.DTOs;
using Northwind.BLL.Repositories;
using Northwind.BLL.Services;
using Northwind.DAL.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TestClass : IOrderRepository
    {
        private readonly NorthwindContext _context;

        public TestClass(NorthwindContext context)
        {
          _context = context;
        }
        public IEnumerable<OrderDTO> GetOrdersInYear(int orderYear)
        {

            var query = _context.Orders
                .Where(order => order.OrderDate.Year == orderYear)
                .GroupBy(order => order.ShipCountry)
                .Select(x => new OrderDTO
                {

                    ShipCountry = x.Key,
                    TotalOrders = x.Count()
                })
                .OrderByDescending(result => result.TotalOrders)
                .ToList();

            return query;
        }
    }
}
