using Microsoft.AspNetCore.Authorization;
using MongoDb.Dtos.OrderDto;
using MongoDb.Services.OrderServices;
using Microsoft.AspNetCore.Mvc;

namespace MongoDb.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderServices _orderServices;
        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }
        public async Task<IActionResult> OrderList()
        {
            var values = await _orderServices.GetAllOrdersAsyn();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto _createOrderDto)
        {
            _createOrderDto.OrderDate = DateTime.Now;
            await _orderServices.CreateOrderAsyn(_createOrderDto);
            return RedirectToAction("Index", "Default");
        }
        public async Task<IActionResult> DeleteOrder(string id)
        {
            await _orderServices.DeleteOrderAsyn(id);
            return RedirectToAction("OrderList");
        }
        public async Task<IActionResult> OrderDetails(string id)
        {
            var value = await _orderServices.GetOrderByIdDto(id);
            return View(value);
        }
    }
}
