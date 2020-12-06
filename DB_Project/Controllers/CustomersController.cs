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
    public class CustomersController : ControllerMongoBase
    {
        public CustomersController(DBService dBService) : base(dBService) { }

        [HttpGet]
        public string GetCustomers()
        {
            var customers = _dbService.GetCustomers();

            var viewCustomers = customers.Select(customer => new Customer(customer));

            return JsonSerializer.Serialize(viewCustomers);
        }

        [HttpGet("{id}")]
        public string GetCustomer(string id)
        {
            var customer = _dbService.GetCustomer(id);

            var viewCustomer = new Customer(customer);

            return JsonSerializer.Serialize(viewCustomer);
        }

        [HttpPost]
        public IActionResult EditCustomer(Models.SaveModels.Customer customer)
        {
            var customerDb = customer.GetDbCustomer();
            _dbService.EditCustomer(customerDb);

            return new OkResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(string id)
        {
            _dbService.DeleteCustomer(id);

            return new OkResult();
        }
    }
}
