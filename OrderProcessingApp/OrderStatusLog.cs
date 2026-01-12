using System;

namespace OrderProcessingApp
{
    /// <summary>
    /// Stores a single order status change entry.
    /// </summary>
    public class OrderStatusLog
    {
        public OrderStatus OldStatus { get; set; }
        public OrderStatus NewStatus { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
