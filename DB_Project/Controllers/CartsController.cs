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

            var viewCarts = carts.Select(cart => new Cart(cart));

            return JsonSerializer.Serialize(viewCarts);
        }

        [HttpGet("{id}")]
        public string GetCart(string id)
        {
            var cart = _dbService.GetCart(id);

            var viewCart = new Cart(cart);

            return JsonSerializer.Serialize(viewCart);
        }

        [HttpPost]
        public void EditCart([FromForm] Models.SaveModels.Cart cart)
        {
            var cartDb = cart.GetDbCart();
            _dbService.EditCart(cartDb);
        }

        [HttpDelete("{id}")]
        public void DeleteCart(string id)
        {
            _dbService.DeleteCart(id);
        }
    }
}
