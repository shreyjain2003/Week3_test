namespace OrderProcessingApp
{
    /// <summary>
    /// Represents all valid states of an order.
    /// Enum ensures type safety and easy future extension.
    /// </summary>
    public enum OrderStatus
    {
        Created,
        Paid,
        Packed,
        Shipped,
        Delivered,
        Cancelled
    }
}
