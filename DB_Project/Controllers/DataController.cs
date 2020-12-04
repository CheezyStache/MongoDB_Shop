using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB_Project.Models;

namespace DB_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerMongoBase
    {
        public DataController(DBService dBService) : base(dBService) { }

        [HttpGet("fill")]
        public async Task<string> FillDb()
        {
            try
            {
                await _dbService.FillWithFakeData();

                await _dbService.FillWithReferences();

                return "success";
            }
            catch(Exception ex)
            {
                return "something gone wrong: " + ex.Message;
            }
            
        }
    }
}
