using RetailEcommerce.Domain.Models.RETAIL;

namespace RetailEcommerce.Domain.Models.DISCOUNTS___VOUCHERS
{
    public class RetailDiscount
    {
        public int RetailDiscountId { get; set; }
        public int RetailTransactionId { get; set; }
        public RetailTransaction RetailTransaction { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
        public decimal AppliedValue { get; set; }
    }
}
