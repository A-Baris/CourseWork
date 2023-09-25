using Microsoft.EntityFrameworkCore;
using Northwind.BLL.DTOs;
using Northwind.BLL.Repositories;
using Northwind.DAL.Models;
using Northwind.DAL.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.Services
{
    public class OrderService : IOrderRepository
    {
        private readonly NorthwindContext _context;

        public OrderService(NorthwindContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            //select ShipCountry,count(ShipCountry) as 'Total Orders' from Orders group by ShipCountry order by [Total Orders] desc
            var query = _context.Orders
           .GroupBy(x => x.ShipCountry)
           .Select(g => new OrderDTO
           {
               ShipCountry = g.Key,
               TotalOrders = g.Count()
           })
           .OrderByDescending(o => o.TotalOrders)
           .ToList();
            return query;
        }

        public IEnumerable<OrderDTO> GetOrdersInYear(int orderYear)
        {

            //select ShipCountry,count(ShipCountry) as 'TotalOrders'from orders where YEAR(OrderDate)=1996 group by ShipCountry order by TotalOrders desc
            var query = _context.Orders
                .Where(order => order.OrderDate.Year == orderYear)
                .GroupBy(order => order.ShipCountry)
                .Select(x => new OrderDTO
                {

                    ShipCountry = x.Key,
                    TotalOrders = x.Count()
                    //key koleksiyon mantığındaki key yapısını temsil eder. Aynı isimdeki key tekrarlanmaz ki buradaki key ShipCountry dir.
                    //Satır sayısı count ile toplanır key e karşılık gelen toplam miktar TotalOrders altında gösterilir.

                })
                .OrderByDescending(result => result.TotalOrders);
     

            return query.ToList();
        }
    }
}
