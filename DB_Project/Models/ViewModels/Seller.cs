using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_Project.Models.ViewModels
{
    public class Seller
    {
        public Seller(Models.Seller seller, Models.Item[] items)
        {
            Id = seller.Id.ToString();
            Name = seller.Name;
            Address = seller.Address;
            IsActive = seller.IsActive;
            Items = items.Select(item => new Entity(item.Id.ToString(), item.Name)).ToArray();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public Entity[] Items { get; set; }
    }
}
