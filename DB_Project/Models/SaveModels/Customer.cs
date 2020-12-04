using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DB_Project.Models.SaveModels
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CartId { get; set; }

        public Models.Customer GetDbCustomer()
        {
            ObjectId? customerId = null;
            ObjectId? cartId = null;

            if (Id != null)
                customerId = ObjectId.Parse(Id);

            if (CartId != null)
                cartId = ObjectId.Parse(CartId);

            return new Models.Customer(Name, Phone, customerId, cartId);
        }
    }
}
