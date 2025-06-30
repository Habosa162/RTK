using RetailEcommerce.Domain.Models.CUSTOMERS___CREDIT;

namespace RetailEcommerce.Domain.Models.DISCOUNTS___VOUCHERS
{
    public class Voucher
    {
        public int VoucherId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int MaxUsage { get; set; }
        public int UsageCount { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
