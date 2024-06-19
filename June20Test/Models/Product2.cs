namespace June20Test.Models
{
    public class Product2
    {
        public int Id { get; set; }
        public int SellerId { get; set; } // Foreign key to Seller
        public virtual Seller? Seller { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        // Navigation property
    }
}
