using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB_Project.Models;

namespace DB_Project.Controllers
{
    public abstract class ControllerMongoBase
    {
        protected readonly DBService _dbService;

        public ControllerMongoBase(DBService dBService)
        {
            _dbService = dBService;
        }
    }
}
