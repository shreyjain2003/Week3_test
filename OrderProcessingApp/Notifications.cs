using System;

namespace OrderProcessingApp
{
    /// <summary>
    /// Contains notification handlers.
    /// </summary>
    public static class Notifications
    {
        public static void NotifyCustomer(Order order, OrderStatus status)
        {
            Console.WriteLine($"[Customer] Order {order.OrderId} is now {status}");
        }

        public static void NotifyLogistics(Order order, OrderStatus status)
        {
            if (status == OrderStatus.Shipped)
                Console.WriteLine($"[Logistics] Dispatch initiated for Order {order.OrderId}");
        }
    }
}
