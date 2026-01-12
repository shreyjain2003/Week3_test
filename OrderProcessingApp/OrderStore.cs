using System.Collections.Generic;

namespace OrderProcessingApp
{
    /// <summary>
    /// Acts as a temporary in-memory database.
    /// Keeps storage separate from business logic.
    /// </summary>

    public static class OrderStore
    {
        public static Dictionary<int, Order> Orders = new();
        public static Dictionary<int, Product> Products = new();
        public static List<string> NotificationLogs = new();
    }
}
