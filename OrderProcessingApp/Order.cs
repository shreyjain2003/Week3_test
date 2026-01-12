using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderProcessingApp
{
    /// <summary>
    /// Represents a customer order with items and status lifecycle.
    /// </summary>
    public class Order
    {
        public int OrderId { get; }
        public Customer Customer { get; }
        public OrderStatus CurrentStatus { get; private set; }

        private readonly List<OrderItem> _items = new();
        private readonly List<OrderStatusLog> _statusHistory = new();

        public IReadOnlyList<OrderItem> Items => _items;
        public IReadOnlyList<OrderStatusLog> StatusHistory => _statusHistory;

        public Order(int orderId, Customer customer)
        {
            OrderId = orderId;
            Customer = customer;
            CurrentStatus = OrderStatus.Created;

            _statusHistory.Add(new OrderStatusLog
            {
                OldStatus = OrderStatus.Created,
                NewStatus = OrderStatus.Created,
                TimeStamp = DateTime.Now
            });
        }

        /// <summary>
        /// Adds an item to the order.
        /// </summary>
        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }

        /// <summary>
        /// Calculates total order amount.
        /// </summary>
        public decimal CalculateTotal()
        {
            return _items.Sum(i => i.GetTotal());
        }

        /// <summary>
        /// Validates and updates order status.
        /// </summary>
        public void ChangeStatus(OrderStatus newStatus)
        {
            if (CurrentStatus == OrderStatus.Cancelled)
                throw new InvalidOperationException("Cancelled order cannot progress.");

            if (newStatus == OrderStatus.Shipped && CurrentStatus != OrderStatus.Packed)
                throw new InvalidOperationException("Order must be packed before shipping.");

            if (newStatus == OrderStatus.Delivered && CurrentStatus != OrderStatus.Shipped)
                throw new InvalidOperationException("Order must be shipped before delivery.");

            var oldStatus = CurrentStatus;
            CurrentStatus = newStatus;

            _statusHistory.Add(new OrderStatusLog
            {
                OldStatus = oldStatus,
                NewStatus = newStatus,
                TimeStamp = DateTime.Now
            });
        }
    }
}
