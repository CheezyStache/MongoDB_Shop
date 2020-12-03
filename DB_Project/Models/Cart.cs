using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_Project.Models
{
    public class Cart
    {
        public ObjectId Id { get; set; }
        public MongoDBRef Customer { get; set; }
        public MongoDBRef[] Items { get; set; }
    }
}
