using Microsoft.AspNetCore.Mvc;
using Northwind.BLL.Repositories;
using Northwind.DAL.Models.Context;

namespace Northwind.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
       

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
           
        }
        [HttpGet]
        public IActionResult Index()
        {

            return View();

        }
        [HttpPost]
        public IActionResult Index(int year)
        {
           ViewBag.Year = year;
            var orders = _orderRepository.GetOrdersInYear(year);
            var ordersList = orders.ToList();
            if (ordersList.Count>0)
            {
                return View(orders);


            }
            TempData["FailMessage"] = "No information in that year";
            
            return RedirectToAction("Index","Order");
           

        }
    }
}
