using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.BLL.Repositories;

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
           _orderRepository = orderRepository;
        }

        [HttpGet]
        [Route("getCountrySale")]
        public IActionResult GetCountrySale()
        {
            var countrySales = _orderRepository.GetOrdersInYear(1996).ToList();

            return Ok(countrySales);
        }


        [HttpGet]
        [Route("getshipstatus")]
        public IActionResult GetShipStatus()
        {

            var shipstatus = _orderRepository.GetShipStatus().ToList();

            Dictionary<int, string> status = new Dictionary<int, string>();

            foreach (var ship in shipstatus) 
            {
                status.Add(ship.OrderId, Enum.GetName(ship.Status));
            }


            return Ok(status);
        }

        [HttpGet]
        [Route("getmonthlyrevenue/{year}/{month}")]
        public IActionResult GetMonthlyRenevue(int year, int month)
        {
            var monthlyRevenue=_orderRepository.GetMonthlyRevenue(year, month).ToList();

            return Ok(monthlyRevenue);
        }

        [HttpGet]
        [Route("getOrderDate")]
        public IActionResult GetOrderDate()
        {
            var orderDate= _orderRepository.GetOrderDate().ToList();
         
            return Ok(orderDate);
        }

    }
}
