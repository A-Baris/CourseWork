using Microsoft.AspNetCore.Mvc;
using Northwind.BLL.Repositories;

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        [Route("order")]
        public IActionResult Index(int year)
        {
            var test = _orderRepository.GetOrdersInYear(year);

            return View(test);
        }
    }
}
