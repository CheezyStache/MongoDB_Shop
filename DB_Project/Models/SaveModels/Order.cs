using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DB_Project.Models.SaveModels
{
    public class Order
    {
        public string Id { get; set; }
        public long DateTimeStamp { get; set; }
        public bool IsCompleted { get; set; }
        public string CustomerId { get; set; }
        public string[] ItemIds { get; set; }

        public Models.Order GetDbOrder()
        {
            var formatDate = DateExtensions.ConvertFromJS(DateTimeStamp);
            var itemIds = ItemIds.Select(itemId => ObjectId.Parse(itemId)).ToArray();

            if (Id != null)
                return new Models.Order(formatDate, IsCompleted, ObjectId.Parse(CustomerId), itemIds, ObjectId.Parse(Id));

            return new Models.Order(formatDate, IsCompleted, ObjectId.Parse(CustomerId), itemIds);
        }
    }
}
