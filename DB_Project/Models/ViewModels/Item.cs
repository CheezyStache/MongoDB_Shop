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

            Seller = seller.Name;
            SellerId = seller.Id.ToString();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public string Seller { get; set; }
        public string SellerId { get; set; }
    }
}
