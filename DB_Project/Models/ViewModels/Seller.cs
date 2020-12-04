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
            IsActive = seller.IsActive;
            ItemIds = seller.Items.Select(item => item.Id.ToString()).ToArray();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string[] ItemIds { get; set; }
    }
}
