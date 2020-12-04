using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_Project.Models
{
    public class Item
    {
        public Item() { }
        public Item(string name, int count, double price, ObjectId sellerId, ObjectId? id = null)
        {
            if(id.HasValue)
                Id = id.Value;

            Name = name;
            Count = count;
            Price = price;
            Seller = new MongoDBRef("Seller", sellerId);
        }

        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public MongoDBRef Seller { get; set; }
    }
}
