using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_Project.Models.ViewModels
{
    public class Cart
    {
        public Cart(Models.Cart cart, Models.Customer customer, Models.Item[] items)
        {
            Id = cart.Id.ToString();
            Customer = new Entity(customer.Id.ToString(), customer.Name);
            Items = items.Select(item => new OrderItem(item)).ToArray();
        }

        public string Id { get; set; }
        public Entity Customer { get; set; }
        public OrderItem[] Items { get; set; }
    }
}
