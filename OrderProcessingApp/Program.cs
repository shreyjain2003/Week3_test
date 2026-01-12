using System;

namespace OrderProcessingApp
{
    class Program
    {
        static void Main()
        {
            /// Sample products
            var prod1 = new Product(1, "Laptop", 90000);
            var prod2 = new Product(2, "Mouse", 900);
            var prod3 = new Product(3, "Keyboard", 2000);
            var prod4 = new Product(4, "Monitor", 50000);
            var prod5 = new Product(5, "Headset", 5000);

            /// Sample customers
            var cust1 = new Customer(1, "Shrey");
            var cust2 = new Customer(2, "Tushar");
            var cust3 = new Customer(3, "Apurav");

            /// Orders
            var order1 = new Order(101, cust1);
            order1.AddItem(new OrderItem(prod1, 1));
            order1.AddItem(new OrderItem(prod2, 2));

            var order2 = new Order(102, cust2);
            order2.AddItem(new OrderItem(prod3, 1));
            order2.AddItem(new OrderItem(prod5, 1));

            var service = new OrderService();

            /// Delegate subscriptions
            service.StatusChanged += Notifications.NotifyCustomer;
            service.StatusChanged += Notifications.NotifyLogistics;

            service.AddOrder(order1);
            service.AddOrder(order2);

            service.UpdateStatus(101, OrderStatus.Paid);
            service.UpdateStatus(101, OrderStatus.Packed);
            service.UpdateStatus(101, OrderStatus.Shipped);
            service.UpdateStatus(101, OrderStatus.Delivered);

            service.UpdateStatus(102, OrderStatus.Shipped); // Invalid transition

            service.PrintReport();

            Console.ReadLine();
        }
    }
}
