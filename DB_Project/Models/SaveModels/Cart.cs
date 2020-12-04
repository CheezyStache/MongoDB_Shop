using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DB_Project.Models.SaveModels
{
    public class Cart
    {
        public string Id { get; set; }

        public string CustomerId { get; set; }
        public string[] ItemIds { get; set; }

        public Models.Cart GetDbCart()
        {
            var itemObjectIds = ItemIds.Select(itemId => ObjectId.Parse(itemId)).ToArray();

            if (Id != null)
                return new Models.Cart(ObjectId.Parse(CustomerId), itemObjectIds, ObjectId.Parse(Id));

            return new Models.Cart(ObjectId.Parse(CustomerId), itemObjectIds);
        }
    }
}
