using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_Project.Models.ViewModels
{
    public class Order
    {
        public Order(Models.Order order)
        {
            Id = order.Id.ToString();
            DateTimeStamp = DateExtensions.ConvertToJS(order.DateTimeStamp);
            IsCompleted = order.IsCompleted;
            CustomerId = order.Customer.Id.ToString();
            ItemIds = order.Items.Select(item => item.Id.ToString()).ToArray();
        }

        public string Id { get; set; }
        public long DateTimeStamp { get; set; }
        public bool IsCompleted { get; set; }
        public string CustomerId { get; set; }
        public string[] ItemIds { get; set; }
    }
}
