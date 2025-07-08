using System.ComponentModel.DataAnnotations;

namespace RetailEcommerce.Domain.Models.CUSTOMERS___CREDIT
{
    public class CustomerCredit
    {
        [Key]
        public int Id { get; set; }
        public int CreditId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } // Charge, Payment, Adjustment
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
