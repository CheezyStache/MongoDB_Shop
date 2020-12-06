using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_Project.Models.ViewModels
{
    public class Entity
    {
        public Entity(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class OrderItem : Entity
    {
        public OrderItem(Models.Item item) : base(item.Id.ToString(), item.Name)
        {
            Price = item.Price;
        }

        public double Price { get; set; }
    }
}
