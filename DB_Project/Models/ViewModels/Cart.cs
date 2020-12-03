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
        }

        public string Id { get; set; }
    }
}
