using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DB_Project.Models;

namespace DB_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly DBService _dbService;

        public TestController(DBService dBService)
        {
            _dbService = dBService;
        }

        [HttpGet("items")]
        public string GetItems()
        {
            var items = _dbService.GetItems();
            var sellers = items.Select(item => _dbService.GetSeller(item.Seller.Id)).ToArray();

            return JsonSerializer.Serialize(items.Select((item, index) => new DB_Project.Models.ViewModels.Item(item, sellers[index])));
        }

        [HttpGet("customers")]
        public string GetCustomers()
        {
            var customers = _dbService.GetCustomers();

            return JsonSerializer.Serialize(customers.Select(customer => new DB_Project.Models.ViewModels.Customer(customer)));
        }

        [HttpGet("sellers")]
        public string GetSellers()
        {
            var sellers = _dbService.GetSellers();

            return JsonSerializer.Serialize(sellers.Select(seller => new DB_Project.Models.ViewModels.Seller(seller)));
        }

        [HttpGet("orders")]
        public string GetOrders()
        {
            var orders = _dbService.GetOrders();

            return JsonSerializer.Serialize(orders.Select(order => new DB_Project.Models.ViewModels.Order(order)));
        }

        [HttpGet("carts")]
        public string GetCarts()
        {
            var carts = _dbService.GetCarts();

            return JsonSerializer.Serialize(carts.Select(cart => new DB_Project.Models.ViewModels.Cart(cart)));
        }

        [HttpDelete("items")]
        public void DeleteItem(string id)
        {
            _dbService.DeleteItem(id);
        }

        [HttpPost("items")]
        public void PostItem([FromForm] string Name, [FromForm] int Count, [FromForm] double Price, [FromForm] string Seller)
        {
            _dbService.PostItem(new Item { Name = Name, Count = Count, Price = Price, Seller = new MongoDB.Driver.MongoDBRef("Seller", MongoDB.Bson.ObjectId.Parse(Seller)) });
        }

        [HttpGet("fill")]
        public async Task<string> FillDb()
        {
            await _dbService.FillWithFakeData();

            await _dbService.FillWithReferences();

            return "success";
        }
    }
}