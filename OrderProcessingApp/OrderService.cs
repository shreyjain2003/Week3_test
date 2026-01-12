using System;
using System.Collections.Generic;

namespace OrderProcessingApp
{
    /// <summary>
    /// Delegate for order status change notifications.
    /// </summary>
    public delegate void OrderStatusChangedHandler(Order order, OrderStatus newStatus);

    /// <summary>
    /// Handles order processing and reporting.
    /// </summary>
    public class OrderService
    {
        //private readonly Dictionary<int, Order> _orders = new();

        public OrderStatusChangedHandler StatusChanged;

        // public void AddOrder(Order order)
        // {
        //     _orders[order.OrderId] = order;
        //     Console.WriteLine($"Order {order.OrderId} created successfully.");
        // }


        public void AddOrder(Order order)
        {
            OrderStore.Orders[order.OrderId] = order;
            Console.WriteLine($"Order {order.OrderId} created successfully.");
        }

        // public void UpdateStatus(int orderId, OrderStatus newStatus)
        // {
        //     try
        //     {
        //         var order = _orders[orderId];
        //         order.ChangeStatus(newStatus);
        //         StatusChanged?.Invoke(order, newStatus);
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Status Change Failed: {ex.Message}");
        //     }
        // }


        public void UpdateStatus(int orderId, OrderStatus newStatus)
        {
            try
            {
                var order = OrderStore.Orders[orderId];
                order.ChangeStatus(newStatus);
                StatusChanged?.Invoke(order, newStatus);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Status Change Failed: {ex.Message}");
            }
        }


        /// <summary>
        /// Prints order summary and full timeline.
        /// </summary>
        public void PrintReport()
        {
            Console.WriteLine("\n===== ORDER REPORT =====");

            foreach (var order in OrderStore.Orders.Values)
            {
                Console.WriteLine($"\nOrder ID: {order.OrderId}, Customer: {order.Customer.Name}");
                Console.WriteLine($"Current Status: {order.CurrentStatus}");
                Console.WriteLine("Items:");

                foreach (var item in order.Items)
                {
                    Console.WriteLine($"- {item.Product.Prod_Name} x{item.Quantity}");
                }

                Console.WriteLine($"Total: ₹{order.CalculateTotal()}");

                Console.WriteLine("Status Timeline:");
                foreach (var log in order.StatusHistory)
                {
                    Console.WriteLine($"{log.TimeStamp}: {log.OldStatus} → {log.NewStatus}");
                }
            }
        }
    }
}
