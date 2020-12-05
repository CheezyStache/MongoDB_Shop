using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_Project.Models.ViewModels
{
    public class Item
    {
        public Item(DB_Project.Models.Item item, Models.Seller seller)
        {
            Id = item.Id.ToString();
            Name = item.Name;
            Count = item.Count;
            Price = item.Price;

            Seller = new Entity(seller.Id.ToString(), seller.Name);
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public Entity Seller { get; set; }
    }
}
