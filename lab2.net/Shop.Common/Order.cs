using System;

namespace Shop.Common
{
    public class Order
    {
        public Guid Id { get; set; }
        public double Total { get; set; }
        public string Customer { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
        }
    }
}