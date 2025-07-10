using RetailEcommerce.Domain.Models.CORE;
using RetailEcommerce.Domain.Models.E_COMMERCE;
using RetailEcommerce.Domain.Models.RETAIL;

namespace RetailEcommerce.Domain.DTOs.Core_DTOs
{
    public class PaymentDto
    {
        public int? PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }
        public int? OrderId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int? RetailTransactionId { get; set; }
        public string PaymentReference { get; set; } // For card payments
    }
}
