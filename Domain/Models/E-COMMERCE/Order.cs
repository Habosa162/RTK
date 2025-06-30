using RetailEcommerce.Domain.Models.CUSTOMERS___CREDIT;

namespace RetailEcommerce.Domain.Models.E_COMMERCE
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; } // Credit, Cash, Card
        public string Status { get; set; } // Pending, Paid, Shipped
        public DateTime CreatedAt { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}
