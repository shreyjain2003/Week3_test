using System;

namespace OrderProcessingApp
{
    class Program
    {
        static void Main()
        {
            /// Sample products
            var p1 = new Product(1, "Laptop", 90000);
            var p2 = new Product(2, "Mouse", 900);
            var p3 = new Product(3, "Keyboard", 2000);
            var p4 = new Product(4, "Monitor", 50000);
            var p5 = new Product(5, "Headset", 5000);

            /// Sample customers
            var c1 = new Customer(1, "Shrey");
            var c2 = new Customer(2, "Tushar");
            var c3 = new Customer(3, "Apurav");

            /// Orders
            var o1 = new Order(101, c1);
            o1.AddItem(new OrderItem(p1, 1));
            o1.AddItem(new OrderItem(p2, 2));

            var o2 = new Order(102, c2);
            o2.AddItem(new OrderItem(p3, 1));
            o2.AddItem(new OrderItem(p5, 1));

            var service = new OrderService();

            /// Delegate subscriptions
            service.StatusChanged += Notifications.NotifyCustomer;
            service.StatusChanged += Notifications.NotifyLogistics;

            service.AddOrder(o1);
            service.AddOrder(o2);

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
