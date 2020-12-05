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

            var viewSellers = sellers.Select(seller => new Seller(seller));

            return JsonSerializer.Serialize(viewSellers);
        }

        [HttpGet("{id}")]
        public string GetSeller(string id)
        {
            var seller = _dbService.GetSeller(id);

            var viewSeller = new Seller(seller);

            return JsonSerializer.Serialize(viewSeller);
        }

        [HttpPost]
        public void EditSeller([FromForm] Models.SaveModels.Seller seller)
        {
            var sellerDb = seller.GetDbSeller();
            _dbService.EditSeller(sellerDb);
        }

        [HttpDelete("{id}")]
        public void DeleteSeller(string id)
        {
            _dbService.DeleteSeller(id);
        }
    }
}
