using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DB_Project.Models.SaveModels
{
    public class Seller
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string[] ItemIds { get; set; }

        public Models.Seller GetDbSeller()
        {
            var itemObjectIds = ItemIds.Select(itemId => ObjectId.Parse(itemId)).ToArray();

            if (Id != null)
                return new Models.Seller(Name, Address, IsActive, itemObjectIds, ObjectId.Parse(Id));

            return new Models.Seller(Name, Address, IsActive, itemObjectIds);
        }
    }
}
