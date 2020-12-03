using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_Project.Models.ViewModels
{
    public class Seller
    {
        public Seller(Models.Seller seller)
        {
            Id = seller.Id.ToString();
            Name = seller.Name;
            Address = seller.Address;
            isActive = seller.isActive;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool isActive { get; set; }
    }
}
