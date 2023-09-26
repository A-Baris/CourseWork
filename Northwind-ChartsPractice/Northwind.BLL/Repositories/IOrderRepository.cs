using Northwind.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.Repositories
{
    public interface IOrderRepository
    {
        //o yıl içerisinde en çok ürün satışı yapılan ülkelerin listelenmesi.
        IEnumerable<CountrySaleDTO> GetOrdersInYear(int orderYear);

        //satışların kargo durumununun gösterilmesi.
        IEnumerable<ShipStatusDTO> GetShipStatus();

        //Aylık olarak yapılan satışlardan elde edilen net kazancı gösterin.
        IEnumerable<MonthlyRevenueDTO> GetMonthlyRevenue(int year, int month);

        //hangi tarihte hangi satışların yapıldığı
        IEnumerable<OrderDateDTO> GetOrderDate();
    }
}
