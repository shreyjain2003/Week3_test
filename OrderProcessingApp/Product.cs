namespace OrderProcessingApp
{
    /// <summary>
    /// Represents a product available for purchase.
    /// </summary>
    public class Product
    {
        public int Prod_Id { get; }
        public string Prod_Name { get; }
        public decimal Prod_Price { get; }

        public Product(int prod_Id, string prod_Name, decimal prod_Price)
        {
            Prod_Id = prod_Id;
            Prod_Name = prod_Name;
            Prod_Price = prod_Price;
        }
    }
}
