using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_Project.Models.ViewModels
{
    public class Cart
    {
        public Cart(Models.Cart cart)
        {
            Id = cart.Id.ToString();
            CustomerId = cart.Customer.Id.ToString();
            ItemIds = cart.Items.Select(item => item.Id.ToString()).ToArray();
        }

        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string[] ItemIds { get; set; }
    }
}
