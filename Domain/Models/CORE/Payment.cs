using RetailEcommerce.Domain.Models.E_COMMERCE;
using RetailEcommerce.Domain.Models.RETAIL;

namespace RetailEcommerce.Domain.Models.CORE
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string PaymentMethod { get; set; } // "Cash", "Card", "Credit"
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }

        public int? OrderId { get; set; }
        public Order Order { get; set; }
        
        
        public int? RetailTransactionId { get; set; }
        public RetailTransaction RetailTransaction { get; set; }
        
        public string PaymentReference { get; set; } // For card payments
    }
}
