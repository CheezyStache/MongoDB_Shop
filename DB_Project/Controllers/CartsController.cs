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
    public class CartsController : ControllerMongoBase
    {
        public CartsController(DBService dBService) : base(dBService) { }

        [HttpGet]
        public string GetCarts()
        {
            var carts = _dbService.GetCarts();
            var items = _dbService.GetItems();
            var customers = carts.Select(order => _dbService.GetCustomer(order.Customer.Id)).ToArray();

            var viewCarts = carts.Select((cart, index) => new Cart(cart, customers[index], items.Where(item => cart.Items.Select(i => i.Id).Contains(item.Id)).ToArray()));

            return JsonSerializer.Serialize(viewCarts);
        }

        [HttpGet("{id}")]
        public string GetCart(string id)
        {
            var cart = _dbService.GetCart(id);
            var items = cart.Items.Select(item => _dbService.GetItem(item.Id)).ToArray();
            var customer = _dbService.GetCustomer(cart.Customer.Id);

            var viewCart = new Cart(cart, customer, items);

            return JsonSerializer.Serialize(viewCart);
        }

        [HttpPost]
        public IActionResult EditCart(Models.SaveModels.Cart cart)
        {
            var cartDb = cart.GetDbCart();
            _dbService.EditCart(cartDb);

            return new OkResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCart(string id)
        {
            _dbService.DeleteCart(id);

            return new OkResult();
        }
    }
}
