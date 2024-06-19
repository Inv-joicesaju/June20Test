namespace June20Test.Models
{
    public class Order2
    {
        public int Id { get; set; }
        public int ProductId { get; set; } // Foreign key to Product
        public virtual Product2? Product2 { get; set; }
        public string CustomerId { get; set; } // Can be the user ID of the customer
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
    }
}
