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
        public Seller() { }
        public Seller(string name, string address, bool IsActive, ObjectId[] itemIds, ObjectId? id = null)
        {
            if (id.HasValue)
                Id = id.Value;

            Name = name;
            Address = address;
            IsActive = IsActive;
            Items = itemIds.Select(itemId => new MongoDBRef("Item", itemId)).ToArray();
        }

        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public MongoDBRef[] Items { get; set; }
    }
}
