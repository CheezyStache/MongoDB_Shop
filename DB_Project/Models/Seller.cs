using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_Project.Models
{
    public class Seller
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool isActive { get; set; }
        public MongoDBRef[] Items { get; set; }
    }
}
