using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBService = DB_Project.Models.DBService;
using DB_Project.Models.ViewModels;
using System.Text.Json;

namespace DB_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerMongoBase
    {
        public OrdersController(DBService dBService) : base(dBService) { }

        [HttpGet]
        public string GetOrders([FromQuery] string userId)
        {
            var orders = _dbService.GetOrders();
            if (userId != null && !string.IsNullOrWhiteSpace(userId))
                orders = orders.Where(order => order.Customer.Id.AsObjectId.ToString() == userId).ToArray();

            var items = _dbService.GetItems();
            var customers = orders.Select(order => _dbService.GetCustomer(order.Customer.Id)).ToArray();

            var viewOrders = orders.Select((order, index) => new Order(order, customers[index], items.Where(item => order.Items.Select(i => i.Id).Contains(item.Id)).ToArray()));

            return JsonSerializer.Serialize(viewOrders);
        }

        [HttpGet("{id}")]
        public string GetOrder(string id)
        {
            var order = _dbService.GetOrder(id);
            var items = order.Items.Select(item => _dbService.GetItem(item.Id)).ToArray();
            var customer = _dbService.GetCustomer(order.Customer.Id);

            var viewOrder = new Order(order, customer, items);

            return JsonSerializer.Serialize(viewOrder);
        }

        [HttpPost]
        public IActionResult EditOrder(Models.SaveModels.Order order)
        {
            _dbService.CreateOrder(order.CustomerId);

            return new OkResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(string id)
        {
            _dbService.DeleteOrder(id);

            return new OkResult();
        }
    }
}
