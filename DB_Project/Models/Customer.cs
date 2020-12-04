using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_Project.Models
{
    public class Customer
    {
        public Customer() { }
        public Customer(string name, string phone, ObjectId? id = null, ObjectId? cartId = null)
        {
            if (id.HasValue)
                Id = id.Value;

            if (cartId.HasValue)
                Cart = new MongoDBRef("Cart", cartId);

            Name = name;
            Phone = phone;
        }

        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public MongoDBRef Cart { get; set; }
    }
}
