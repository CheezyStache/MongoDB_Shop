using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DB_Project.Models.SaveModels
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public string Seller { get; set; }

        public Models.Item GetDbItem()
        {
            if(Id != null)
                return new Models.Item(Name, Count, Price, ObjectId.Parse(Seller), ObjectId.Parse(Id));

            return new Models.Item(Name, Count, Price, ObjectId.Parse(Seller));
        }
    }
}
