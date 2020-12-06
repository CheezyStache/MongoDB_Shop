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
    public class SellersController : ControllerMongoBase
    {
        public SellersController(DBService dBService) : base(dBService) { }

        [HttpGet]
        public string GetSellers()
        {
            var sellers = _dbService.GetSellers();
            var items = _dbService.GetItems();

            var viewSellers = sellers.Select((seller, index) => new Seller(seller, items.Where(item => seller.Items != null && seller.Items.Select(i => i.Id).Contains(item.Id)).ToArray()));

            return JsonSerializer.Serialize(viewSellers);
        }

        [HttpGet("{id}")]
        public string GetSeller(string id)
        {
            var seller = _dbService.GetSeller(id);
            var items = seller.Items != null ? seller.Items.Select(item => _dbService.GetItem(item.Id)).ToArray() : new Models.Item[0];

            var viewSeller = new Seller(seller, items);

            return JsonSerializer.Serialize(viewSeller);
        }

        [HttpPost]
        public IActionResult EditSeller(Models.SaveModels.Seller seller)
        {
            var sellerDb = seller.GetDbSeller();
            _dbService.EditSeller(sellerDb);

            return new OkResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSeller(string id)
        {
            _dbService.DeleteSeller(id);

            return new OkResult();
        }
    }
}
