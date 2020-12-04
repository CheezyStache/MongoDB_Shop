using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_Project.Models
{
    public class Order
    {
        public Order() { }
        public Order(DateTime dateTimeStamp, bool isCompleted, ObjectId customerId, ObjectId[] itemIds, ObjectId? id = null)
        {
            if (id.HasValue)
                Id = id.Value;

            DateTimeStamp = dateTimeStamp;
            IsCompleted = isCompleted;
            Customer = new MongoDBRef("Customer", customerId);
            Items = itemIds.Select(itemId => new MongoDBRef("Item", itemId)).ToArray();
        }

        public ObjectId Id { get; set; }
        public DateTime DateTimeStamp { get; set; }
        public bool IsCompleted { get; set; }
        public MongoDBRef Customer { get; set; }
        public MongoDBRef[] Items { get; set; }
    }
}
