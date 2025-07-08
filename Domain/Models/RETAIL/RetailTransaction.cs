using RetailEcommerce.Domain.Models.CORE;
using RetailEcommerce.Domain.Models.CUSTOMERS___CREDIT;
using System.ComponentModel.DataAnnotations;

namespace RetailEcommerce.Domain.Models.RETAIL
{
    public class RetailTransaction
    {
        [Key]
        public int TransactionId { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CashierId { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<RetailTransactionItem> Items { get; set; }
        public ICollection<Payment> Payments { get; set; }

    }
}
