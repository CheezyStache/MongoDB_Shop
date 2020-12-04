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
        public Cart() { }
        public Cart(ObjectId customerId, ObjectId[] itemIds, ObjectId? id = null)
        {
            if (id.HasValue)
                Id = id.Value;

            Customer = new MongoDBRef("Customer", customerId);
            Items = itemIds.Select(itemId => new MongoDBRef("Item", itemId)).ToArray();
        }

        public ObjectId Id { get; set; }
        public MongoDBRef Customer { get; set; }
        public MongoDBRef[] Items { get; set; }
    }
}
