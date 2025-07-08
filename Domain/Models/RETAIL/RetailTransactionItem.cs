using RetailEcommerce.Domain.Models.Core;
using System.ComponentModel.DataAnnotations;

namespace RetailEcommerce.Domain.Models.RETAIL
{
    public class RetailTransactionItem
    {
        [Key]
        public int TransactionItemId { get; set; }
        public int TransactionId { get; set; }
        public RetailTransaction Transaction { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
