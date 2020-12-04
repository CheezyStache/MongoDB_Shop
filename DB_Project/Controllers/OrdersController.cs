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

            var viewOrders = orders.Select(order => new Order(order));

            return JsonSerializer.Serialize(viewOrders);
        }

        [HttpGet("{id}")]
        public string GetOrder(string id)
        {
            var order = _dbService.GetOrder(id);

            var viewOrder = new Order(order);

            return JsonSerializer.Serialize(viewOrder);
        }

        [HttpPost]
        public void EditOrder([FromForm] Models.SaveModels.Order order)
        {
            var orderDb = order.GetDbOrder();
            _dbService.EditOrder(orderDb);
        }

        [HttpDelete]
        public void DeleteOrder(string id)
        {
            _dbService.DeleteOrder(id);
        }
    }
}
