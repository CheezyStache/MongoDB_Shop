using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_Project.Models.ViewModels
{
    public class Order
    {
        public Order(Models.Order order, Models.Customer customer, Models.Item[] items)
        {
            Id = order.Id.ToString();
            DateTimeStamp = DateExtensions.ConvertToJS(order.DateTimeStamp);
            IsCompleted = order.IsCompleted;
            Customer = new Entity(customer.Id.ToString(), customer.Name);
            Items = items.Select(item => new OrderItem(item)).ToArray();
        }

        public string Id { get; set; }
        public long DateTimeStamp { get; set; }
        public bool IsCompleted { get; set; }
        public Entity Customer { get; set; }
        public OrderItem[] Items { get; set; }
    }
}
