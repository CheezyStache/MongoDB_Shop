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
    public class ItemsController : ControllerMongoBase
    {
        public ItemsController(DBService dBService) : base(dBService) { }

        [HttpGet]
        public string GetItems()
        {
            var items = _dbService.GetItems();
            var sellers = items.Select(item => _dbService.GetSeller(item.Seller.Id)).ToArray();

            var viewItems = items.Select((item, index) => new Item(item, sellers[index]));

            return JsonSerializer.Serialize(viewItems);
        }

        [HttpGet("{id}")]
        public string GetItem(string id)
        {
            var item = _dbService.GetItem(id);
            var seller = _dbService.GetSeller(item.Seller.Id);

            var viewItem = new Item(item, seller);

            return JsonSerializer.Serialize(viewItem);
        }

        [HttpPost]
        public void EditItem(Models.SaveModels.Item item)
        {
            var itemDb = item.GetDbItem();
            _dbService.EditItem(itemDb);
        }

        [HttpDelete("{id}")]
        public void DeleteItem(string id)
        {
            _dbService.DeleteItem(id);
        }
    }
}
