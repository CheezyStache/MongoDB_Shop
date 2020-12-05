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
        public string GetOrders()
        {
            var orders = _dbService.GetOrders();
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
        public void EditOrder([FromForm] Models.SaveModels.Order order)
        {
            var orderDb = order.GetDbOrder();
            _dbService.EditOrder(orderDb);
        }

        [HttpDelete("{id}")]
        public void DeleteOrder(string id)
        {
            _dbService.DeleteOrder(id);
        }
    }
}
