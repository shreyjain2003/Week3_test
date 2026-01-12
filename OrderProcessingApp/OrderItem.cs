namespace OrderProcessingApp
{
    /// <summary>
    /// Represents a single item inside an order.
    /// Demonstrates composition (Order HAS OrderItems).
    /// </summary>
    public class OrderItem
    {
        public Product Product { get; }
        public int Quantity { get; }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public decimal GetTotal()
        {
            return Product.Prod_Price * Quantity;
        }
    }
}
